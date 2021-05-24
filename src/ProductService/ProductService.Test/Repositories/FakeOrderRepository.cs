using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.Test.Repositories
{
    public class FakeOrderRepository : IOrderRepository
    {
        public void Dispose(){}

        public Task<List<Order>> Filter(Expression<Func<Order, bool>> func){
            return null;
        }

        public Task Insert(Order order) {
            return Task.FromResult(true);
        }
    }
}
