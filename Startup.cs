using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
namespace LearnAspNetCoreMvc
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        //get configuration from constructor
        public Startup(IConfiguration configuration){
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Dependency injection
            //add singleton (1 per app)
            services.AddSingleton<IFeatureToggle>((serviceProvider => {
                bool isProd = serviceProvider.GetService<IWebHostEnvironment>().IsProduction();
                return new FeatureToggle(isProd);
            }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IFeatureToggle featureToggle)
        {
            Console.WriteLine("env:" + env.EnvironmentName);
            Console.WriteLine("config priority: " + configuration["CONFIG_PRIORITY_CODE"]);
            Console.WriteLine("should use feature: "+featureToggle.shouldRun());
            app.UseExceptionHandler("/error.html");
            if (configuration.GetValue<bool>("IS_DEV_ENV"))
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.Use(async(context,next)=>
            {
                if(context.Request.Path.Value.Contains("invalid")){
                    throw new Exception("cannot handdle");
                }
                await next();
            });
            app.UseFileServer();
        }
    }
}
