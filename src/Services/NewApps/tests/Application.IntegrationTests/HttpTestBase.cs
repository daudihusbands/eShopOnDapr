using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Termites.API;
using Xunit;
using Xunit.Abstractions;

namespace Termites.Tests.Integration
{
    public abstract class HttpTestBase<TStartup> : IClassFixture<CustomFactory<TStartup>>
        where TStartup : class
    {
        protected CustomFactory<Startup> factory;
        protected HttpClient client;
        protected readonly ITestOutputHelper output;

        public HttpTestBase(CustomFactory<Startup> factory, ITestOutputHelper output)
        {
            this.factory = factory;

            client = factory.CreateClient();

            this.output = output;

        }
        protected async Task<TResponse> Post<TResponse>(object model, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var json = JsonConvert.SerializeObject(model);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {


                output.WriteLine(responseContent);
            }

            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }

    }
}
