using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebShop.DAL.Context;
using WebShop.Data;
using WebShop.Infrastructure.Interfaces;
using WebShop.Infrastructure.Middleware;
using WebShop.Infrastructure.Services;

namespace WebShop
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebShopDB>(opt => opt.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<WebShopDBInitializer>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            
            services.AddScoped<IEmployeesData, InMemoryEmployeesData>();

            services.AddScoped<IProductData, InMemoryProductData>();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebShopDBInitializer db)
        {
            db.Initialize();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseRouting();
            app.UseWelcomePage("/welcome");

            app.UseMiddleware<TestMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
