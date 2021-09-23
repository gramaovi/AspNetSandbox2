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
        public enum ExitCodes
        {
            /// <summary>Exit code for no errors.</summary>
            NoError = 0,

            /// <summary>Exit code for invalid arguments.</summary>
            InvalidArguments = 1,
        }

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
            if (args.Length == 1 && HelpRequired(args[0]))
            {
                Console.WriteLine("Help needed!");
            }
            else if (args.Length > 1)
            {
                Console.WriteLine($"There are {args.Length} arguments.");
            }
            else if (args.Length == 0)
            {
                Console.WriteLine("There are no arguments.");
            }
            CreateHostBuilder(args).Build().Run();
            return 0;
        }
        private static bool HelpRequired(string argument)
        {
            return argument == "-h" || argument == "--help" || argument == "-?";
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
