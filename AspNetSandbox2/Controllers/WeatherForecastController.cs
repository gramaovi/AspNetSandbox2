using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandbox2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

 

        public WeatherForecastController()
        {
            
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather?lat=45.6427&lon=25.5887&appid=baf0ee4e9de6d933b877336983a0b1c8");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertResponseToWeatherForecast(response.Content);

            
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
            
        }

        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content)
        {
            var json = JObject.Parse(content);
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = (int)(json["daily"][0]["temp"].Value<float>("day") - 273.15f),
                Summary = json["daily"][0]["weather"][0].Value<string>("main")
            })
            .ToArray();
        }
    }
}
