using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using WebAPI;

namespace WebAPI_IntegrationTest
{
    public class BaseIntegrationTest
    {
        public HttpClient Client { get; set; }
        public string ApiUri { get; set; }
        public BaseIntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            Client = appFactory.CreateClient();
            ApiUri = Client?.BaseAddress?.AbsoluteUri;
        }

        public StringContent JsonData<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
