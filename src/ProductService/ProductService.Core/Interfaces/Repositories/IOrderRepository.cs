using ProductService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.Core.Interfaces.Repositories
{
    public interface IOrderRepository : IDisposable
    {
        Task<List<Order>> Filter(Expression<Func<Order, bool>> func);
        Task Insert(Order order);
    }
}
