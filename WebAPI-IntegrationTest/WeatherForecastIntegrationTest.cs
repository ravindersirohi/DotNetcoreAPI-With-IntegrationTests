using Xunit;
using System;
using System.Net;
using System.Threading.Tasks;
using WebAPI;

namespace WebAPI_IntegrationTest
{
    public class WeatherForecastIntegrationTest : BaseIntegrationTest
    {
        private string WeatherEndPoint { get; set; }
        public WeatherForecastIntegrationTest()
        {
            WeatherEndPoint = $"{ApiUri}WeatherForecast";
        }

        [Fact]
        public void GetWeatherForcastIntegrationTest()
        {
            try
            {

                var result = Task.Run(async () => await Client.GetAsync(WeatherEndPoint)).Result;
                Assert.True(result != null && result.StatusCode == HttpStatusCode.OK, "Get Weather Forcast Integration Test Completed");
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        [Fact]
        public void PostWeatherForcastIntegrationTest()
        {
            try
            {
                var weatherForecast = new WeatherForecast { Date = DateTime.Now, TemperatureC = 25, Summary = "Today's weather" };
                var data = JsonData(weatherForecast);

                var result = Task.Run(async () => await Client.PostAsync(WeatherEndPoint, data)).Result;
                Assert.True(result != null && result.StatusCode == HttpStatusCode.OK, "Post Weather Forcast Integration Test Completed");
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }
    }
}
