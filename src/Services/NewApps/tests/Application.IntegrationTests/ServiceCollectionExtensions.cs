using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewApps.Infrastructure.Persistence;

namespace NewApps.Application.IntegrationTests;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection Remove<TService>(this IServiceCollection services)
    {
        var serviceDescriptor = services.FirstOrDefault(d =>
            d.ServiceType == typeof(TService));

        if (serviceDescriptor != null)
        {
            services.Remove(serviceDescriptor);
        }

        return services;
    }

    //public static IServiceCollection AddTestDbContexts(this IServiceCollection services, bool? useSqlite = true)
    //{
    //    var dtccConnectionString = "DataSource=:memory:";
    //    // var suitDdtccConnectionString = "DataSource=:memory:";
    //    //var dtccConnectionString = "DataSource=Apps.db";
    //    //var suitDdtccConnectionString = "DataSource=Suitability.db";


    //    if (useSqlite.GetValueOrDefault())
    //    {
    //        // Todo - use NoOpMediator here
    //        var serviceProvider = services.BuildServiceProvider();
    //        var mediator = serviceProvider.GetRequiredService<IMediator>();

    //        services.AddScoped(sp =>
    //        {

    //            var _connection = new SqliteConnection(dtccConnectionString);
    //            _connection.Open();
    //            _connection.EnableExtensions();

    //            var options = new DbContextOptionsBuilder<AppDataContext>()
    //                    .UseSqlite(_connection, sqlOptions =>
    //                    {
    //                    })
    //                    .EnableSensitiveDataLogging()
    //                    .Options;
    //            var dbContext = new AppDataContext(options, mediator);
    //            dbContext.Database.EnsureCreated();
    //            return dbContext;

    //        });



    //    }
    //    else
    //    {
    //        // we are only doing setup here because we need to Drop/Recreate the database
    //        var serviceProvider = services
    //             .BuildServiceProvider();

    //        var connectionString = serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection");

    //        services.AddDbContext<AppDataContext>((host, opts) =>
    //        {
    //            opts.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(AppDataContext).Assembly.FullName));
    //        });




    //    }

    //    return services;
    //}

}
