using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using ProductService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositories
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private readonly FidelityContext _dbContext;

        public OrderHistoryRepository(FidelityContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        ~OrderHistoryRepository() { Dispose(false); }

        void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        #endregion

        public async Task<List<OrderHistory>> GetList(int orderId)
        {
            return await _dbContext.OrderHistories
                                   .Include(x => x.OrderStatus)
                                   .Where(x => x.OrderId == orderId)
                                   .OrderBy(x => x.RegistrationDate)
                                   .ToListAsync();
        }
    }
}
