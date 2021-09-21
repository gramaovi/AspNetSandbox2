using AspNetSandbox2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox2.Data
{
    public static class DataTools
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {

                var applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (applicationDbContext.Book.Any())
                {
                    Console.WriteLine("the books are there");
                }
                else
                {
                    var book = new Book
                    {
                        Title = "In search of lost time",
                        Author = "Marcel Proust",
                        Language = "English",
                    };
                    applicationDbContext.Add(book);
                    var book2 = new Book
                    {
                        Title = "Ulysses",
                        Author = "James Joyce",
                        Language = "English",
                    };
                    applicationDbContext.Add(book2);
                    applicationDbContext.SaveChanges();

                }
            }
        }
    }
}
