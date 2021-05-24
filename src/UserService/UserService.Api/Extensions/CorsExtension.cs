using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace UserService.Api.Extensions
{
    public static class CorsExtension
    {
        public static void AddCorsExtension(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", build =>
            {
                string[] domainsAlloweds = new string[] {
                    "http://localhost:5100",
                    "http://gateway.api:5100"
                };

                build.WithOrigins(domainsAlloweds)
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                    .AllowCredentials();
            }));
        }

        public static void UseCorsExtension(this IApplicationBuilder app)
        {
            app.UseCors("ApiCorsPolicy");
        }
    }
}