using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandbox2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private const float KELVIN_CONST = 273.15f;
        [NonAction]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=46.31006&lon=23.72128&exclude=hourly,minutely&appid=3c01003ea64a26fde6e1fbeef8591064");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertResponseToWeatherForecast(response.Content);

            

        }
        [NonAction]
        public CityCoordonates GetLocation()
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather?q=Brasov&appid=3c01003ea64a26fde6e1fbeef8591064");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertResponseToLocation(response.Content);
        }

        private CityCoordonates ConvertResponseToLocation(string content)
        {
            var json = JObject.Parse(content);
            JToken jsonCoords = json["coord"];

            return new CityCoordonates
            {
                Latitude = ExtractLatitudeFromCoordonates(jsonCoords),
                Longitude =ExtractLongitudeFromCoordonates(jsonCoords)

            };

        }
        [NonAction]
        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content,int days = 5)
        {
            var json = JObject.Parse(content);
            var rng = new Random();
            return Enumerable.Range(1, days).Select(index =>
            {
                JToken jsonDailyForecast = json["daily"][index];
                var unixDateTime = jsonDailyForecast.Value<long>("dt");
                string weatherSummary = jsonDailyForecast["weather"][0].Value<string>("main");
                return new WeatherForecast
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    //Date = DateTime.Now.AddDays(index),
                    TemperatureC = ExtractCelsiusTemperatureFromDailyWeather(jsonDailyForecast),
                    Summary = weatherSummary
                };
            })
            .ToArray();
        }

        private static int ExtractCelsiusTemperatureFromDailyWeather(JToken jsonDailyForecast)
        {
            return (int)Math.Round(jsonDailyForecast["temp"].Value<float>("day") - KELVIN_CONST);
        }
        private static string ExtractLatitudeFromCoordonates(JToken jsonCoords)
        {
            return "Lat: " + jsonCoords.Value<string>("lat");
        }
        private static string ExtractLongitudeFromCoordonates(JToken jsonCoords)
        {
            return "Lat: " + jsonCoords.Value<string>("lon");
        }
    }
}
