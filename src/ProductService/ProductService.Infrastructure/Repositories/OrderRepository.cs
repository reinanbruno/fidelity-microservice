using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using ProductService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FidelityContext _dbContext;

        public OrderRepository(FidelityContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        ~OrderRepository() { Dispose(false); }

        void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        #endregion


        public async Task<List<Order>> Filter(Expression<Func<Order, bool>> func)
        {
            return await _dbContext.Orders
                                   .Include(x => x.Product)
                                   .Include(x => x.OrderStatus)
                                   .Include(x => x.UserAddress)
                                   .Where(func)
                                   .OrderBy(x => x.RegistrationDate)
                                   .ToListAsync();
        }

        public async Task Insert(Order order)
        {
            await _dbContext.AddAsync(order);
        }

    }
}
