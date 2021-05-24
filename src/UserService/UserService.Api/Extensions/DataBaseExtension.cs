using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Infrastructure.Context;

namespace UserService.Api.Extensions
{
    public static class DataBaseExtension
    {
        public static void AddDataBaseExtension(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = (configuration["DB_CONNECTION_STRING"] ?? configuration.GetConnectionString("FidelityContext"));
            services.AddDbContext<FidelityContext>(options => options.UseMySQL(connectionString));
        }
    }
}
