using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using ProductService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
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


        public async Task<User> Find(Expression<Func<User, bool>> func)
        {
            return await _dbContext.Users
                                   .Include(x => x.UserAddresses)
                                   .Where(func)
                                   .FirstOrDefaultAsync();
        }

        public async Task Update(User user)
        {
            _dbContext.Users.Attach(user);
            _dbContext.Entry(user).Property(x => x.CurrentPointsBalance).IsModified = true;

        }
    }
}
