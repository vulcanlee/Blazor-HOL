using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using School.WebApp.Data;
using School.WebApp.Helpers;
using School.WebApp.RazorModels;
using School.WebApp.Services;
using ShareBusiness.Helpers;
using Syncfusion.Blazor;

namespace School.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSyncfusionBlazor();

            #region Blazor 專案產生的預設內容
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            #endregion

            var foo = Configuration.GetConnectionString(MagicHelper.DefaultConnectionString);
            services.AddDbContext<SchoolContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString(
                MagicHelper.DefaultConnectionString)), ServiceLifetime.Transient);
            AddOtherServices(services);
            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Startup));
        }

        private static void AddOtherServices(IServiceCollection services)
        {
            #region 註冊服務
            services.AddTransient<IDepartmentService, DepartmentService>();
            #endregion

            #region 註冊 Razor Model
            services.AddTransient<DepartmentRazorModel>();
            #endregion

            #region 其他服務註冊
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("License Key");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
