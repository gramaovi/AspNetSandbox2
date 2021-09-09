using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandbox2.Controllers
{
    /// <summary>
    /// Controller that allow us to get weather forecast.
    /// </summary>
        [ApiController]
        [Route("[controller]")]
        public class WeatherForecastController : ControllerBase
        {
            public WeatherForecastController()
            {
            }

        /// <summary>
        /// Getting weather forcast for 5 days.
        /// </summary>
        /// <returns>
        /// Enumerable of weather forecast objects.
        /// </returns>
            [HttpGet]
            public IEnumerable<WeatherForecast> Get()
            {
                var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=46.31006&lon=23.72128&exclude=hourly,minutely&appid=3c01003ea64a26fde6e1fbeef8591064");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

                return ConvertResponseToWeatherForecast(response.Content);
            }

            [NonAction]
            public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content, int days = 5)
            {
                var json = JObject.Parse(content);
                var rng = new Random();

                return Enumerable.Range(1, days).Select(index =>
                {
                    JToken jsonDailyForecast = json["daily"][index - 1];
                    var unixDateTime = json["daily"][index - 1].Value<long>("dt");

                    return new WeatherForecast
                    {
                        Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                        TemperatureC = jsonDailyForecast["temp"].Value<int>("day") - 272,
                        Summary = jsonDailyForecast["weather"][0].Value<string>("main"),
                    };
                })
                .ToArray();
            }
        }

        [ApiController]
        [Route("[controller]")]
        public class WeatherForecastForCoordController : ControllerBase
        {
            public WeatherForecastForCoordController()
            {
            }

            [HttpGet]
            public WeatherForecastLatLong Get()
            {
                var client = new RestClient("http://api.openweathermap.org/data/2.5/weather?q=Brasov&appid=1637fc62cd976a8699f16ac5f7d9b92f");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

                return ConvertResponseToCoords(response.Content);
            }

            [NonAction]
            public WeatherForecastLatLong ConvertResponseToCoords(string content)
            {
                var json2 = JObject.Parse(content);

                return new WeatherForecastLatLong
                {
                    Lat = json2["coord"].Value<float>("lat"),
                    Longit = json2["coord"].Value<float>("lon"),
                };
            }
        }
}
