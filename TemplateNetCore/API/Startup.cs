using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using API.Assets;
using Data.Data.APIContext.Context;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using API.Assets.Middleware;

namespace API
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
            //Connection SQL
            var connection = Configuration.GetConnectionString("LocalDB");

            //DbContext
            services.AddDbContext<APIContext>(options => options.UseSqlServer(connection).EnableSensitiveDataLogging(true));

            //AutoMapper
            services.AddAutoMapper(typeof(AutoMapping));

            //Authentication
            services.AddCors();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API",
                    Description = "Template ASP.NET Core Web API",
                    TermsOfService = new Uri("https://www.Lynxview.com/")
                });
            });

            //Scrutor Dependency Injection
            //A?adir el nombre completo del ensamblado (ejemplo:test.Core)
            services.Scan(scan => scan
                .FromAssemblies(Assembly.Load("Core"), Assembly.Load("Data"))
                .AddClasses(c => c.Where(d =>
                    d.Name.EndsWith("Service")
                    || d.Name.EndsWith("Repository")
                    || d.Name.EndsWith("Factory")
                    || d.Name.EndsWith("Access")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            //Swagger
            if (!env.IsProduction() || !env.IsStaging())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.OAuthAppName("API V1");                    
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                });
            }
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = new JsonExceptionMiddleware().Invoke
                });
            }
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
