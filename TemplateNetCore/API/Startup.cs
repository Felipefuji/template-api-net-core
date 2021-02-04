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
using Data.Data.AuthContext.Models;
using Data.Data.AuthContext.Context;
using Microsoft.AspNetCore.Identity;

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
            //DbContext
            AddDbContexts(services, Configuration.GetConnectionString("LocalDB"));

            //AutoMapper
            services.AddAutoMapper(typeof(AutoMapping));

            //Authentication
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;
            }).AddEntityFrameworkStores<AuthContext>().AddDefaultTokenProviders();

            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));

            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();
            services.AddAuth(jwtSettings);
            //Policity
            services.AddCors();

            // Register the Swagger generator, defining 1 or more Swagger documents
            AddSwagger(services);

            //Scrutor Dependency Injection
            AddScrutor(services);
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                ConfigureSwagger(app);
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            ConfigureCors(app);

            ConfigureExceptionHandler(app);

            app.UseAuth();

            ConfigureUseEndPoints(app);
        }

        #region services

        private void AddDbContexts(IServiceCollection services, string connection)
        {
            services.AddDbContext<APIContext>(options => options.UseSqlServer(connection).EnableSensitiveDataLogging(true));
            services.AddDbContext<AuthContext>(options => options.UseSqlServer(connection).EnableSensitiveDataLogging(true));
        }
   
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API",
                    Description = "Template ASP.NET Core Web API",
                    TermsOfService = new Uri("https://hydratech.es/")
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT containing userid claim",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                var security =
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                },
                                UnresolvedReference = true
                            },
                            new List<string>()
                        }
                    };
                options.AddSecurityRequirement(security);
            });
        }

        private void AddScrutor(IServiceCollection services)
        {
            //Add full name assembly (ejemplo:test.Core)
            services.Scan(scan => scan
                .FromAssemblies(Assembly.Load("Core"), Assembly.Load("Data"))
                .AddClasses(c => c.Where(d =>
                    d.Name.EndsWith("Service")
                    || d.Name.EndsWith("Repository")
                    || d.Name.EndsWith("Factory")
                    || d.Name.EndsWith("Access")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }

        #endregion
        #region Configure
        private void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthAppName("API V1");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }

        private void ConfigureCors(IApplicationBuilder app)
        {
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        }

        private void ConfigureExceptionHandler(IApplicationBuilder app)
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new JsonExceptionMiddleware().Invoke
            });
        }

        private void ConfigureUseEndPoints(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #endregion
    }
}
