using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetSandbox2;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class StartupTest
    {
        [Fact]
        public void CheckConversionToEFConnectionString()
        {
            // Assume
            string databaseUrl = "postgres://vneponkvjjiqqb:6d2fd7d56fb389fcf4f11c2dffea206a4ca7f6aa898d58ee2db025cfa0081d6d@ec2-44-195-247-84.compute-1.amazonaws.com:5432/d8nkn7e021eal0";

            // Act
            string convertedConnectionString = Startup.ConvertConnectionString(databaseUrl);

            // Assert
            Assert.Equal("Server=ec2-44-195-247-84.compute-1.amazonaws.com;Port=5432;Database=d8nkn7e021eal0;User Id=vneponkvjjiqqb;Password=6d2fd7d56fb389fcf4f11c2dffea206a4ca7f6aa898d58ee2db025cfa0081d6d;SSL Mode=Require;Trust Server Certificate=true", convertedConnectionString);
        }
    }
}
