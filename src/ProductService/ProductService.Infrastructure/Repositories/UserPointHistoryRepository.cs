using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using ProductService.Infrastructure.Context;
using System;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositories
{
    public class UserPointHistoryRepository : IUserPointHistoryRepository
    {
        private readonly FidelityContext _dbContext;

        public UserPointHistoryRepository(FidelityContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        ~UserPointHistoryRepository() { Dispose(false); }

        void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        #endregion

        public async Task Insert(UserPointHistory userPointHistory)
        {
            await _dbContext.AddAsync(userPointHistory);
        }

    }
}
