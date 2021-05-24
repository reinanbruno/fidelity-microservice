using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.Test.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public FakeProductRepository()
        {
            _products.Add(new Product { ProductId = 1, PointsValue = 5, Active = 1, Name = "Produto 1" });
            _products.Add(new Product { ProductId = 2, PointsValue = 10, Active = 1, Name = "Produto 2" });
            _products.Add(new Product { ProductId = 3, PointsValue = 15, Active = 1, Name = "Produto 3" });
        }

        public void Dispose(){}

        public Task<List<Product>> Filter(int? categoryId, int? subcategoryId){
            return Task.FromResult(_products);
        }

        public Task<Product> Find(Expression<Func<Product, bool>> func)
        {
            return Task.FromResult(_products.Where(func.Compile()).FirstOrDefault());
        }
    }
}
