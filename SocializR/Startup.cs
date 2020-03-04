using AutoMapper;
using DataAcces.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RouteJs;
using SocializR.Code.ExtensionMethods;
using SocializR.Code.Settings;

namespace SocializR
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
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));
            services.AddScoped<UnitOfWork>();
            services.AddSingleton<AppSettings>();
            services.AddBusinessLogic();

            services.AddCurrentUser();
            services.AddAuthentication(Code.Security.Constants.AuthentificationScheme)
                   .AddCookie(Code.Security.Constants.AuthentificationScheme, options =>
                   {
                       options.AccessDeniedPath = new PathString("/Account/Login");
                       options.LoginPath = new PathString("/Account/Login");
                   });
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddRouteJs();
            services.AddAutoMapper();
            services.AddMvc();

        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Feed}/{action=Index}/{id?}");
            });
        }
    }
}
