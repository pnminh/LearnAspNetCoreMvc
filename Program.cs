using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnAspNetCoreMvc.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LearnAspNetCoreMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()){
                var services = scope.ServiceProvider;
                try {
                    SeedDataSpecial.Initialize(services);
                }catch(Exception e){
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e,"An error occurred seeding DB");
                }
            }
            host.Run();//this kicks off the Configure method from Startup class
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();//this will run the ConfigureServices which create DI
                });
    }
}
