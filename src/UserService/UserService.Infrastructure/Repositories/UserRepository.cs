using UserService.Core.Interfaces.Repositories;
using UserService.Core.Models;
using UserService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UserService.Infrastructure.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly FidelityContext _dbContext;

        public UserRepository(FidelityContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        ~UserRepository() { Dispose(false); }

        void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        #endregion

        public async Task<int> Insert(User user)
        {
            await _dbContext.Users.AddAsync(user);
            return user.UserId;
        }

        public async Task<User> Find(Expression<Func<User, bool>> func)
        {
            return await _dbContext.Users.Where(func).FirstOrDefaultAsync();
        }

        public async Task<decimal> GetPointsBalance(int userId)
        {
            return await _dbContext.Users
                                   .Where(x => x.UserId == userId)
                                   .Select(x => x.CurrentPointsBalance)
                                   .FirstOrDefaultAsync();
        }
    }
}
