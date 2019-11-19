using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxiApp.DataAccess;

namespace TaxiApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(x => x.UseSqlServer("Server=A-205-2;Database=ShopDb;Trusted_Connection=true;"));
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddRazorPages();
        }

      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //routeBuilder.MapRoute("default", "api/{controller}");

                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapRoute("default", "api/{controller}");
            });

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});



            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //	endpoints.MapGet("/", async context =>
            //	{
            //		await context.Response.WriteAsync("Hello World!");
            //	});
            //});
        }
    }
}
