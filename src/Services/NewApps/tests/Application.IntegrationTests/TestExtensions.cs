using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Termites.Tests.Integration
{
    public static class TestExtensions
    {
        public static TService GetService<TService>(this WebApplicationFactory<Startup> @class)
            where TService : class
        {
            return @class.Server?.GetService<TService>();
        }
        public static TService GetRequiredService<TService>(this WebApplicationFactory<Startup> @class)
            where TService : class
        {
            return @class.Server?.GetRequiredService<TService>();
        }

        public static async Task<HttpResponseMessage> PostContent(this HttpClient _client, object model, string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);

            var json = JsonConvert.SerializeObject(model);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);

            return response;
        }

        public static async Task<TContent> GetContent<TContent>(this HttpResponseMessage httpResponse)
        {
            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TContent>(responseContent);
        }


        public static TService GetService<TService>(this TestServer @class)
            where TService : class
        {
            return @class.Host?.Services?.GetService(typeof(TService)) as TService;
        }
        public static TService GetRequiredService<TService>(this TestServer @class)
            where TService : class
        {
            return @class.Host?.Services?.GetRequiredService(typeof(TService)) as TService;
        }

        //public static void Log(this ITestOutputHelper helper, object data)
        //{

        //    var str = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
        //    {
        //        Formatting = Formatting.Indented,
        //        NullValueHandling = NullValueHandling.Ignore,
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //    });
        //    helper.WriteLine(str);
        //}

        public static IWebHost MigrateDbContext<TContext>(this IWebHost webHost,
            Action<TContext, IServiceProvider> seeder)
            where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var logger = services.GetRequiredService<ILogger<TContext>>();

                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation($"Migrating database associated with context {typeof(TContext).Name}");

                    //var retry = Policy.Handle<SqlException>()
                    //     .WaitAndRetry(new TimeSpan[]
                    //     {
                    //         TimeSpan.FromSeconds(3),
                    //         TimeSpan.FromSeconds(5),
                    //         TimeSpan.FromSeconds(8),
                    //     });

                    //retry.Execute(() =>
                    //{
                    //    //if the sql server container is not created on run docker compose this
                    //    //migration can't fail for network related exception. The retry options for DbContext only 
                    //    //apply to transient exceptions.

                    //    context.Database.Migrate();

                    //    seeder(context, services);
                    //});


                    logger.LogInformation($"Migrated database associated with context {typeof(TContext).Name}");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"An error occurred while migrating the database used on context {typeof(TContext).Name}");
                }
            }

            return webHost;
        }

        public static MultipartFormDataContent MultipartFormDataContent(string fileName, Dictionary<string, string> formData)
        {
            var multiPartContent = new MultipartFormDataContent("boundary=---011000010111000001101001");
            using (var outFile = new StreamWriter(fileName))
            {
                outFile.WriteLine("bleh bleh bleh");
            }

            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var streamContent = new StreamContent(fileStream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");

            // Add the file key/value
            multiPartContent.Add(streamContent, "file", fileName);

            // Add the keys
            foreach (var kvp in formData)
            {
                multiPartContent.Add(new StringContent(kvp.Value), kvp.Key);
            }

            return multiPartContent;
        }


        public static MultipartFormDataContent MultipartFormDataContent(IEnumerable<string> fileNames, Dictionary<string, string> formData)
        {
            var multiPartContent = new MultipartFormDataContent("boundary=---011000010111000001101001");

            foreach (var fileName in fileNames)
            {
                var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                var streamContent = new StreamContent(fileStream);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");

                // Add the file key/value
                multiPartContent.Add(streamContent, "files", fileName);
            }


            // Add the keys
            foreach (var kvp in formData)
            {
                multiPartContent.Add(new StringContent(kvp.Value), kvp.Key);
            }

            return multiPartContent;
        }


        public static HttpRequestMessage HttpRequestMessage(IEnumerable<string> fileNames, Dictionary<string, string> formData)
        {
            var requestContent = MultipartFormDataContent(fileNames, formData);
            var message = new HttpRequestMessage();
            message.Content = requestContent;
            return message;
        }
        public static string AsQueryString(this Dictionary<string, object> formData)
        {
            // Initilization.  

            var kvp = formData.Select(x => new KeyValuePair<string, string>(x.Key, x.Value.ToString())).ToList();

            // URL Request Query parameters.  
            var queryString = new FormUrlEncodedContent(kvp).ReadAsStringAsync().Result;
            return queryString;
        }

        /// <summary>
        /// Removes all registered <see cref="ServiceLifetime.Transient"/> registrations of <see cref="TService"/> and adds in <see cref="TImplementation"/>.
        /// </summary>
        /// <typeparam name="TService">The type of service interface which needs to be placed.</typeparam>
        /// <typeparam name="TImplementation">The test or mock implementation of <see cref="TService"/> to add into <see cref="services"/>.</typeparam>
        /// <param name="services"></param>
        public static void SwapTransient<TService, TImplementation>(this IServiceCollection services)
            where TImplementation : class, TService
        {
            if (services.Any(x => x.ServiceType == typeof(TService) && x.Lifetime == ServiceLifetime.Transient))
            {
                var serviceDescriptors = services.Where(x => x.ServiceType == typeof(TService) && x.Lifetime == ServiceLifetime.Transient).ToList();
                foreach (var serviceDescriptor in serviceDescriptors)
                {
                    services.Remove(serviceDescriptor);
                }
            }

            services.AddTransient(typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        /// Removes all registered <see cref="ServiceLifetime.Transient"/> registrations of <see cref="TService"/> and adds a new registration which uses the <see cref="Func{IServiceProvider, TService}"/>.
        /// </summary>
        /// <typeparam name="TService">The type of service interface which needs to be placed.</typeparam>
        /// <param name="services"></param>
        /// <param name="implementationFactory">The implementation factory for the specified type.</param>
        public static void SwapTransient<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory)
        {
            if (services.Any(x => x.ServiceType == typeof(TService) && x.Lifetime == ServiceLifetime.Transient))
            {
                var serviceDescriptors = services.Where(x => x.ServiceType == typeof(TService) && x.Lifetime == ServiceLifetime.Transient).ToList();
                foreach (var serviceDescriptor in serviceDescriptors)
                {
                    services.Remove(serviceDescriptor);
                }
            }

            services.AddTransient(typeof(TService), (sp) => implementationFactory(sp));
        }

        public static IServiceCollection Replace<TInterface, TInstance>(this IServiceCollection services)
             where TInterface : class
             where TInstance : TInterface
        {
            services.Remove(new ServiceDescriptor(typeof(TInterface), typeof(TInstance)));
            services.AddScoped(typeof(TInterface), typeof(TInstance));
            return services;

        }

        public static IServiceCollection Replace(this IServiceCollection services, Type tInterface, object tInstance)

        {
            services.Remove(new ServiceDescriptor(tInterface, _ => _.GetService(tInterface), ServiceLifetime.Scoped));
            services.Remove(new ServiceDescriptor(tInterface, _ => _.GetService(tInterface), ServiceLifetime.Transient));
            services.AddTransient(tInterface, tInstance.GetType());
            return services;
        }





    }
}
