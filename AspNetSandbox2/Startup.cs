using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AspNetSandbox;
using AspNetSandbox2.Data;
using AspNetSandbox2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AspNetSandbox2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
                     services.AddDbContext<ApplicationDbContext>(options =>

                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));
                     services.AddDatabaseDeveloperPageExceptionFilter();

                     services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
                     services.AddRazorPages();
                     services.AddControllers();
                     services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi2", Version = "v1" });

                // <MARKED> Set the comments path for the Swagger JSON and UI .
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                // <MARKED>.
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                // <MARKED>.
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
                     services.AddScoped<IBookRepository, DbBooksRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi2 v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            var defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames = new List<string>();
            defaultFilesOptions.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(defaultFilesOptions);
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapRazorPages();
            });
        }
    }

    // api.openweathermap.org/data/2.5/weather?lat=45.6427&lon=25.5887&appid=baf0ee4e9de6d933b877336983a0b1c8.
}
