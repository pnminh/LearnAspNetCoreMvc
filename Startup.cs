using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnAspNetCoreMvc.Models;
using LearnAspNetCoreMvc.Repositories;
using LearnAspNetCoreMvc.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
 
namespace LearnAspNetCoreMvc
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<IFormatService, FormatService>();
            services.AddDbContext<IdentityDataContext>(options => {
                var connString = _configuration.GetConnectionString("IdentityDataContext");
                options.UseSqlServer(connString);
            });
            services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<IdentityDataContext>();
            services.ConfigureApplicationCookie(options => {
                options.LoginPath = $"/Account/Login";//default login route
                options.LogoutPath = $"/Account/Logout";//default logout route
            });
            services.AddDbContext<SpecialDataContext>(options =>
            {
                var connString = _configuration.GetConnectionString("SpecialDataContext");
                options.UseSqlServer(connString);
            });
            services.AddDbContext<BlogDataContext>(options =>
            {
                var connString = _configuration.GetConnectionString("BlogDataContext");
                //method extension
                options.UseSqlServer(connString);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer();
            /* app.UseDefaultFiles();
            app.UseStaticFiles(); */
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpointRouteBuilder =>
            {
                endpointRouteBuilder.MapControllerRoute("Default", "{Controller=Home}/{action=Index}/{id?}");
            });
            //app.UseFileServer();
        }
    }
}
