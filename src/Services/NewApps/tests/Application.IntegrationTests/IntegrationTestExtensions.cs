using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Termites.Domain.SeedWork;
using Termites.Infrastructure;

namespace Nwl.Dtcc.IntegrationTests
{
    public static class IntegrationTestExtensions
    {


        public static IServiceCollection AddDbContexts(this IServiceCollection services, bool? useSqlite = true)
        {
            var dtccConnectionString = "DataSource=:memory:";
            if (useSqlite.GetValueOrDefault())
            {
                services.AddScoped(sp =>
                {

                    var _connection = new SqliteConnection(dtccConnectionString);
                    _connection.Open();
                    _connection.EnableExtensions();

                    var options = new DbContextOptionsBuilder<AppDataContext>()
                            .UseSqlite(_connection, sqlOptions =>
                            {
                            })
                            .EnableSensitiveDataLogging()
                            .Options;
                    var dbContext = new AppDataContext(options);
                    dbContext.Database.EnsureCreated();
                    return dbContext;

                });


            }
            else
            {
                // we are only doing setup here because we need to Drop/Recreate the database
                var serviceProvider = services
                     .BuildServiceProvider();

                var appSettings = new AppSettings();
                var config = serviceProvider.GetService<IConfiguration>();
                config.Bind(appSettings);
                var connectionString = appSettings.ConnectionStrings.TermitesDataContext;

                services.AddDbContext<AppDataContext>((host, opts) =>
{
                    opts.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(AppDataContext).Assembly.FullName));
                });

            }

            return services;
        }


    }
}
