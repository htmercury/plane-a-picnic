using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.Domain.Repositories;
using plane_a_picnic.Domain.Services;
using plane_a_picnic.Repositories;
using plane_a_picnic.Services;
using plane_a_picnic.Settings.Middleware;
using plane_a_picnic.Settings.Options;

namespace plane_a_picnic
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
            services.Configure<OpenWeatherOptions>(Configuration.GetSection("OpenWeather"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMemoryCache();
            services.AddResponseCaching();

            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<IOpenWeatherRepository, OpenWeatherRepository>();
            services.AddScoped<IOpenWeatherService, OpenWeatherService>();

            services.AddHttpClient("openWeather", c => 
                c.BaseAddress = new Uri("https://api.openweathermap.org/")
            );

            services.AddDbContext<ModelContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            // In production, the Aurelia files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseResponseCaching();
            app.UseCachingMiddleware();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer(baseUri: "http://localhost:8080");
                }
            });
        }
    }
}