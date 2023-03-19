using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HusJel.Applications.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewApps.Application.IntegrationTests;

namespace Termites.Tests.Integration
{
    public class TestBase
    {
        private const string ConnectionString = "DataSource=:memory:";
        private SqliteConnection _connection;

        protected AppDataContext dataContext;

        public TestServer CreateServer(bool? useRealDatabase = false)
        {
            var builder = CreateBuilder(useRealDatabase: useRealDatabase);

            return new TestServer(builder);
        }
        public static string ContentRoot = Path.GetDirectoryName(Assembly.GetAssembly(typeof(TestBase)).Location);
        public static string AppSettingsFile = "appsettings.IntegrationTests.json";
    //    private static Checkpoint checkpoint = new Checkpoint
    //    {
    //        TablesToIgnore = new Table[]
    //{
    //            "sysdiagrams",
    //            "__EFMigrationsHistory",
    //            "tblUser",
    //            "tblObjectType",
    //            new Table("MyOtherSchema", "MyOtherTable")
    //},
    //        SchemasToExclude = new[]
    //{
    //            "RoundhousE"
    //        }
    //    };

         public IWebHostBuilder CreateBuilder(Action<ContainerBuilder> testConfiguration = null, bool? registerDefaultIdentity = true, bool? registerDefaultWorkflow = true, bool? useRealDatabase = false)
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(ContentRoot)
                .ConfigureAppConfiguration(cfg =>
                {
                    cfg
                   .AddEnvironmentVariables()
                   //.AddUserSecrets<TestStartup>()
                   .AddJsonFile(AppSettingsFile, optional: false)
                   ;
                })
                .ConfigureServices((services) =>
                {

                    // must inject Autofac implementation of IServiceProviderFactory<ContainerBuilder>
                    services.AddAutofac();

                    // we are only doing setup here because we need to Drop/Recreate the database
                    var serviceProvider = services
                         .AddEntityFrameworkInMemoryDatabase()
                         .BuildServiceProvider();

                    //var appSettings = new AppSettings();
                    //serviceProvider.GetService<IConfiguration>().Bind(appSettings);

                    var config = serviceProvider.GetService<IConfiguration>();
                    useRealDatabase = useRealDatabase.GetValueOrDefault() || 
                        //appSettings.UseSqlExpressForTests.GetValueOrDefault() || 
                        config.GetValue<bool>("useSqlExpressForTests");

                    if (useRealDatabase.GetValueOrDefault())
                    {
                        services.AddSingleton(sp =>
                        {


                            var sqlExpressConn = config.GetConnectionString(nameof(ConnectionStrings.DefaultConnection));// appSettings.ConnectionStrings.TermitesDataContext;

                            var options = new DbContextOptionsBuilder<AppDataContext>()
                                .UseSqlServer(sqlExpressConn, sqlOptions =>
                                {
                                    //sqlOptions.UseNetTopologySuite();
                                })
                                .EnableSensitiveDataLogging()
                                .EnableDetailedErrors()
                                .Options;

                            dataContext = new AppDataContext(options, new NoMediator());
                            ////dataContext.Database.EnsureDeleted();
                            ////dataContext.Database.EnsureCreated();
                            ////dataContext.Database.Migrate();

                            //checkpoint.Reset(sqlExpressConn).Wait();


                            return dataContext;

                        });
                    }
                    else
                        //services.AddScoped(_ => UnitTestBase.CreateInMemoryDb());

                    services.AddSingleton(sp =>
                    {

                        _connection = new SqliteConnection(ConnectionString);
                        _connection.Open();
                        //_connection.EnableExtensions();
                        //SpatialiteLoader.Load(_connection);

                        var options = new DbContextOptionsBuilder<AppDataContext>()
                            .UseSqlite(_connection, sqlOptions =>
                            {
                                //sqlOptions.UseNetTopologySuite();
                            })
                            .EnableSensitiveDataLogging()
                            .EnableDetailedErrors()
                            .Options;

                        dataContext = new AppDataContext(options, new NoMediator());
                        dataContext.Database.EnsureDeleted();
                        dataContext.Database.EnsureCreated();

                        return dataContext;

                    });

                    //new FactoryInitialization().Initialize(serviceProvider);

                })
                .ConfigureTestContainer<ContainerBuilder>(builder =>
                {

                    //builder.RegisterModule(new ApplicationModule());
                    //builder.RegisterModule(new MediatorModule());

                    if (registerDefaultIdentity.GetValueOrDefault())
                    {

                        //builder.Register(fact =>
                        //{
                        //    // configure authorization to bypass any permissions check
                        //    var authService = new Mock<IAuthorizationServiceProxy>();
                        //    authService.Setup(x => x.IsAuthorized(It.IsAny<Microsoft.AspNetCore.Authorization.AuthorizationPolicy>())).Returns(Task.FromResult(true));

                        //    authService.Setup(x => x.TryRunPermissionCheck(null, It.IsAny<string[]>())).Returns(Task.FromResult(true));
                        //    return authService.Object;
                        //}).As<IAuthorizationServiceProxy>();

                        //builder.Register(fact =>
                        //{
                        //    // configure identity to bypass any user info
                        //    var authService = new Mock<IIdentityService>();
                        //    authService.Setup(x => x.GetUserIdentity()).Returns("testUser");
                        //    authService.Setup(x => x.GetUserName()).Returns("testUser");

                        //    return authService.Object;
                        //}).As<IIdentityService>();


                    }

                    // Handle any additional test configuration
                    if (testConfiguration != null)
                    {
                        testConfiguration.Invoke(builder);
                    }
                })
                .UseStartup<TestStartup>()
                ;
            return builder;
        }
    }


    class NoMediator : IMediator
    {
        public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            return default(IAsyncEnumerable<TResponse>);
        }

        public IAsyncEnumerable<object?> CreateStream(object request, CancellationToken cancellationToken = default)
        {
            return default(IAsyncEnumerable<object?>);
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            return Task.CompletedTask;
        }

        public Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            return Task.FromResult<TResponse>(default(TResponse));
        }

        public Task<object> Send(object request, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(default(object));
        }

        public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest
        {
            return Task.CompletedTask;
        }
    }

}
