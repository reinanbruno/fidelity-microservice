using ProductService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.Core.Interfaces.Repositories
{
    public interface IProductRepository : IDisposable
    {
        Task<Product> Find(Expression<Func<Product, bool>> func);
        Task<List<Product>> Filter(int? categoryId, int? subcategoryId);
    }
}
