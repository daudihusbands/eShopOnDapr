using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewApps.Application.Common.Interfaces;
using NewApps.Application.Holdings;
using NewApps.Infrastructure.Identity;
using NewApps.Infrastructure.Persistence;
using NewApps.Infrastructure.Persistence.Interceptors;
using NewApps.Infrastructure.Repositories;
using NewApps.Infrastructure.Services;

namespace NewApps.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<AppDataContext>(options =>
                options.UseInMemoryDatabase("NewAppsDb"));
        }
        else
        {
            services.AddDbContext<AppDataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(AppDataContext).Assembly.FullName)));
        }
        // services.AddScoped<IHoldingRepository, HoldingRepository>();
        services.AddScoped<IHoldingRepository>(provider => new HoldingRepository( provider.GetRequiredService<AppDataContext>()));

        //services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();
        services.AddTransient<IDateTime, DateTimeService>();

        //services
        //    .AddDefaultIdentity<ApplicationUser>()
        //    .AddRoles<IdentityRole>()
        //    .AddEntityFrameworkStores<AppDataContext>();

        //services.AddIdentityServer()
        //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        //services.AddTransient<IIdentityService, IdentityService>();
        //services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        //services.AddAuthentication()
        //    .AddIdentityServerJwt();

        //services.AddAuthorization(options =>
        //    options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }
}
