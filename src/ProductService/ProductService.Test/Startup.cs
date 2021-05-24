using Microsoft.Extensions.DependencyInjection;
using ProductService.Core.Interfaces;
using ProductService.Core.Interfaces.Repositories;
using ProductService.Test.Repositories;
using ProductService.Test.UoW;

namespace ProductService.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, FakeUnitOfWork>();
            services.AddScoped<IUserRepository, FakeUserRepository>();
            services.AddScoped<IOrderRepository, FakeOrderRepository>();
            services.AddScoped<IProductRepository, FakeProductRepository>();
            services.AddScoped<IUserPointHistoryRepository, FakeUserPointHistoryRepository>();
        }
    }
}
