using UserService.Core.Interfaces;
using UserService.Core.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using UserService.Test.Repositories;
using UserService.Test.UoW;

namespace UserService.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, FakeUnitOfWork>();
            services.AddScoped<IUserAddressRepository, FakeUserAddressRepository>();
            services.AddScoped<IUserRepository, FakeUserRepository>();
        }
    }
}
