using System;
using Library.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Library
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
            services.AddControllers();
            services.AddDbContext<LibraryContext>(opt =>
                opt.UseSqlite("Data Source=Database.db")
                );
            services.AddCors();

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddOpenApiDocument();

/*             // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            }); */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpLogging();
            app.UseCors(options =>
            {
                options.AllowAnyMethod().AllowAnyHeader();
                options.SetIsOriginAllowed((host) => true);
                options.AllowCredentials();
            });
            // Add these before app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
            //    app.UseSpaStaticFiles();
            }
        
            app.UseOpenApi();
            app.UseSwaggerUi3();
        




            /* app.UseSpa(spa =>
                      {
                          // To learn more about options for serving a SPA app from ASP.NET Core,
                          // see https://go.microsoft.com/fwlink/?linkid=864501

                          spa.Options.SourcePath = "../wwwroot";

                           if (env.IsDevelopment())
                          {
                              var port = Environment.GetEnvironmentVariable("PORT") ?? "4200";
                              spa.UseProxyToSpaDevelopmentServer($"http://localhost:{port}");
                          }
                          else
                          {
                              // HTTPS redirection will break Rollup's livereload
                              //app.UseHttpsRedirection();
                          } 
                      }); */
            app.UseRouting();
            app.UseEndpoints(e => e.MapControllers());

        }
        
    }
}