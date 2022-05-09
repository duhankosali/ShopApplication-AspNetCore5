using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopApplication.Business.Abstract;
using ShopApplication.Business.Concrete;
using ShopApplication.DataAccess.Abstract;
using ShopApplication.DataAccess.Concrete.EntityFramework;
using ShopApplication.DataAccess.Concrete.Memory;
using ShopApplication.UI.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApplication.UI
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
            services.AddControllersWithViews();

            // Dependency Injection ile ProductDal istendi�inde kullan�c�ya hangisi g�nderilsin? --> Bu k�s�m� kullanarak istedi�imiz an de�i�iklik yapabiliriz.
            //services.AddScoped<IProductDal, MemoryProductDal>(); // MemoryProductDal'daki veriler �a��r�l�r.
            services.AddScoped<IProductDal, EfCoreProductDal>(); // SqlServer'deki veriler �a��r�l�r.
            services.AddScoped<IProductService, ProductManager>();

            services.AddMvc();
            // IProduct, EfCoreProductDal
            // IProduct, MySqlProductDal
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                SeedDatabase.Seed(); // Bizim olu�turdu�umuz SeedDatabase s�n�f�. �ncele
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(); // wwroot u d��ar� a�mak i�in bir middleware (kendisi otomatik yaz�l� geliyor)

            //app.CustomStaticFiles(); // Middleware klas�r�n�n i�inde kendi olu�turdu�umu bir Middleware (30)

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
