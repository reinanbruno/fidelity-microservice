using UserService.Core.Interfaces.Repositories;
using UserService.Core.Models;
using UserService.Infrastructure.Context;
using System;
using System.Threading.Tasks;

namespace UserService.Infrastructure.Repositories
{
    public sealed class UserAddressRepository : IUserAddressRepository
    {
        private readonly FidelityContext _dbContext;

        public UserAddressRepository(FidelityContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        ~UserAddressRepository() { Dispose(false); }

        void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        #endregion

        public async Task<int> Insert(UserAddress userAddress)
        {
            await _dbContext.UserAddresses.AddAsync(userAddress);
            return userAddress.UserAddressId;
        }

    }
}
