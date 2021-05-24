using UserService.Core.Interfaces.Repositories;
using UserService.Core.Models;
using UserService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UserService.Infrastructure.Repositories
{
    public sealed class UserPointHistoryRepository : IUserPointHistoryRepository
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

        public async Task<List<UserPointHistory>> Filter(Expression<Func<UserPointHistory, bool>> func)
        {
            return await _dbContext.UserPointHistories
                                   .Where(func)
                                   .ToListAsync();
        }

    }
}
