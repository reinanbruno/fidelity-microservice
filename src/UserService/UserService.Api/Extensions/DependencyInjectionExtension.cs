using UserService.Core.Interfaces;
using UserService.Core.Interfaces.Repositories;
using UserService.Core.Interfaces.Services;
using UserService.Infrastructure.Repositories;
using UserService.Infrastructure.Services;
using UserService.Infrastructure.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace UserService.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjectionExtension(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddScoped<IUserPointHistoryRepository, UserPointHistoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();            
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICryptographyService, CryptographyService>();
        }
    }
}
