using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NewApps.Application.IntegrationTests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration, IHostEnvironment env) : base(configuration, env)
        {

        }
        public override void ConfigureAuthPipeline(IApplicationBuilder app)
        {
            if (Configuration.GetValue<bool>("isTest") == true)
            {
                app.UseMiddleware<AutoAuthenticateMiddleware>();
            }
            else
                base.ConfigureAuthPipeline(app);
        }

        public override void ConfigureSwagger(IApplicationBuilder app, string pathBase)
        {

        }

        public override void ConfigureDb(IServiceCollection services)
        {
            //services.AddTransient<DatabaseInitializer>();
        }


    }
}
