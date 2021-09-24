using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week12ProductsProject.Services;
using Microsoft.EntityFrameworkCore;
using Week12ProductsProject.Models;

namespace Week12ProductsProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IProductRepository, ProductRepository>();

            //using sqlite to create a db from Employecontext which has class employee/ Data source what we choose
            services.AddDbContext<ProductContext>(options => options.UseSqlite("Data Source = product.db"));
            services.AddScoped<IProductRepository, DBRepository>();//need to register the services here NEXT inject services  //should use Scooped
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ProductContext productContext)
        {
            productContext.Database.EnsureCreated(); //make sure database is created and there in the pipeline
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
