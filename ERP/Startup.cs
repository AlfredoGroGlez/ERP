using ERP.AccesoDatos;
using ERP.AccesoDatos.Models;
using ERP.AccesoDatos.Repository;
using ERP.Filter;
using ERP.Negocio.Login;
using ERP.Negocio.Login.Interfaces;
using ERP.Utilidades.Encryption;
using ERP.Utilidades.Mail;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ERP
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<ERPContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BdErp")));
            services.AddScoped<IEncryption, Encryption>();
            services.AddScoped<ISendMail, SendMail>();
            services.AddScoped<ILnLogin, LnLogin>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<FilterSeguridad>();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Acceso}/{action=Index}/{id?}");
            });
        }
    }
}
