using ProductService.Core.Interfaces;
using ProductService.Core.Interfaces.Repositories;
using ProductService.Infrastructure.Repositories;
using ProductService.Infrastructure.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace ProductService.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjectionExtension(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserPointHistoryRepository, UserPointHistoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IOrderHistoryRepository, OrderHistoryRepository>();
        }
    }
}
