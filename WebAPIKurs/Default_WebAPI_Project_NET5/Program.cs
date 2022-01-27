using Default_WebAPI_Project_NET5.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Default_WebAPI_Project_NET5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();


            //Fr�hste Zugriff auf IOC in .NET 5
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                ITimeService timeservice = services.GetRequiredService<ITimeService>();
                try
                {
                    string thetime =  timeservice.GetCurrentTime();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run(); 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //weitere Methoden
    }
}
