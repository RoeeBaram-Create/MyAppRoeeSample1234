using FunProject.Application.ActivityLogModule.Services;
using FunProject.Application.ActivityLogModule.Services.Interfaces;
using FunProject.Application.CustomersModule.Services;
using FunProject.Application.CustomersModule.Services.Interfaces;
using FunProject.Domain;
using FunProject.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FunProject.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInrustractureLayerServices();
            services.AddPersistanceLayerServices();

            // application services
            services.AddTransient<ICustomersService, CustomersService>();
            services.AddTransient<IActivityLogService, ActivityLogService>();
            
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
                var sampleData = serviceScope.ServiceProvider.GetService<ISampleData>();
                sampleData.SeedDataAsync();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
