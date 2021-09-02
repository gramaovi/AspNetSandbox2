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
            Assert.Equal("Rain", ((WeatherForecast[])output)[0].Summary);
            Assert.Equal(13, ((WeatherForecast[])output)[0].TemperatureC);
        }
    }
}
