using ProductService.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Core.Interfaces.Repositories
{
    public interface IOrderHistoryRepository : IDisposable
    {
        Task<List<OrderHistory>> GetList(int orderId);
    }
}
