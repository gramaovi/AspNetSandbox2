using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetSandbox2
{
    public class Program
    {
        public static int Main(string[] args)
        {
           
         if(args.Length>0)
            {
                Console.WriteLine($"There are: {args.Length} args.");
            }
         else
            {
                Console.WriteLine("No arguments");
            }
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
