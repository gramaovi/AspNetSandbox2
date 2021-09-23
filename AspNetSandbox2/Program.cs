using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox2.Data;
using CommandLine;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetSandbox2
{
    public class Program
    {
        public class Options
        {
            [Option('c', "connectionString", Required = false, HelpText = "Set the default connection string.")]
            public string ConnectionString { get; set; }
        }
        public static int Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
             .WithParsed<Options>(options =>
             {
                 DataTools.connectionString = $"{options.ConnectionString}";
             });
            CreateHostBuilder(args).Build().Run();
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
