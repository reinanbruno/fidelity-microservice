using ProductService.Api.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace ProductService.Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Assembly assembly = AppDomain.CurrentDomain.Load("ProductService.Application");
            services.AddDependencyInjectionExtension();
            services.AddMediatR(assembly);
            services.AddResponseCompressionExtension();
            services.AddCorsExtension();
            services.AddMvcExtension(assembly);
            services.AddControllersExtensions();
            services.AddSwaggerExtension();
            services.AddDataBaseExtension(_configuration);
            services.AddAutoMapper(assembly);
            services.AddJwtSecurity(_configuration);
            services.AddHealthChecks();
            services.AddConsulExtension(_configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLocalizationExtension();
            app.UseConsulExtension(env.EnvironmentName);
            app.UseRouting();
            app.UseCorsExtension();
            app.UseExceptionHandlerExtension();
            app.UseEndPointsExtension();
            app.UseResponseCompressionExtension();
            app.UseSwaggerExtension();
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
