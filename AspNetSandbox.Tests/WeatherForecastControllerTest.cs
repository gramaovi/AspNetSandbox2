using System;
using System.IO;
using AspNetSandbox2;
using AspNetSandbox2.Controllers;
using Xunit;

namespace AspNetSandbox.Tests
{
    /// <summary>
    /// Test Suite for WeatherForecastController.
    /// </summary>
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void ConvertResponseToWeatherForecastForTomorrowTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastForTommorrow = ((WeatherForecast[])output)[0];
            Assert.Equal("Clouds", weatherForecastForTommorrow.Summary);
            Assert.Equal(20, ((WeatherForecast[])output)[0].TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 2), weatherForecastForTommorrow.Date);
        }

        [Fact]
        public void ConvertResponseToWeatherForecastForAfterTommorowTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastForAfterTommorrow = ((WeatherForecast[])output)[1];
            Assert.Equal("Clear", weatherForecastForAfterTommorrow.Summary);
            Assert.Equal(20, ((WeatherForecast[])output)[0].TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 3), weatherForecastForAfterTommorrow.Date);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataFromOpenWeatherAPI.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
