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
            services.AddScoped<DIRequestScope>();
            services.AddSingleton<DISingletonScope>();
            services.AddTransient<DITransientScope>();
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
            List<IDIScope> requestScopeObjsFirstHandler = new List<IDIScope>();
            List<IDIScope> singletonScopeObjsFirstHandler = new List<IDIScope>();
            List<IDIScope> transientScopeObjsFirstHandler = new List<IDIScope>();
            

            app.Use(async (context,next) =>
            {
                requestScopeObjsFirstHandler.Add(context.RequestServices.GetService<DIRequestScope>());
                singletonScopeObjsFirstHandler.Add(context.RequestServices.GetService<DISingletonScope>());
                transientScopeObjsFirstHandler.Add(context.RequestServices.GetService<DITransientScope>());
                await context.Response.WriteAsync($"First Handler: requests:{string.Join(",",requestScopeObjsFirstHandler)}, singletons: {string.Join(",",singletonScopeObjsFirstHandler)}, transients: {string.Join(",",transientScopeObjsFirstHandler)}\n");
                await next();
            });
            List<IDIScope> requestScopeObjsSecondHandler = new List<IDIScope>();
            List<IDIScope> singletonScopeObjsSecondHandler = new List<IDIScope>();
            List<IDIScope> transientScopeObjsSecondHandler = new List<IDIScope>();
             app.Run(async (context) =>
            {
                requestScopeObjsSecondHandler.Add(context.RequestServices.GetService<DIRequestScope>());
                singletonScopeObjsSecondHandler.Add(context.RequestServices.GetService<DISingletonScope>());
                transientScopeObjsSecondHandler.Add(context.RequestServices.GetService<DITransientScope>());
                await context.Response.WriteAsync($"Second handler: requests:{string.Join(",",requestScopeObjsSecondHandler)}, singletons: {string.Join(",",singletonScopeObjsSecondHandler)}, transients: {string.Join(",",transientScopeObjsSecondHandler)}\n");
                
            });
        }
    }
}
