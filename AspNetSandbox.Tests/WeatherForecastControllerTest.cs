using System;
using AspNetSandbox2;
using AspNetSandbox2.Controllers;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void ConvertResponseToWeatherForecastTest()
        {
            // Assume
            string content = "{\"coord\":{\"lon\":25.5887,\"lat\":45.6427},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":284.69,\"feels_like\":283.99,\"temp_min\":283.52,\"temp_max\":290.67,\"pressure\":1017,\"humidity\":80},\"visibility\":10000,\"wind\":{\"speed\":4.65,\"deg\":312,\"gust\":10.15},\"clouds\":{\"all\":100},\"dt\":1630565690,\"sys\":{\"type\":2,\"id\":2039162,\"country\":\"RO\",\"sunrise\":1630554012,\"sunset\":1630601694},\"timezone\":10800,\"id\":686060,\"name\":\"Atias\",\"cod\":200}";
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastAfterTommorrow = ((WeatherForecast[])output)[1];
            Assert.Equal("Clear", weatherForecastAfterTommorrow.Summary);
            Assert.Equal(21, ((WeatherForecast[])output)[0].TemperatureC);
            Assert.Equal(new DateTime(2021,9,4), weatherForecastAfterTommorrow.Date);
        }
    }
}
