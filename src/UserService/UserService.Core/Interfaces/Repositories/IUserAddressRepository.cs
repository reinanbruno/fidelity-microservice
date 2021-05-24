using UserService.Core.Models;
using System;
using System.Threading.Tasks;

namespace UserService.Core.Interfaces.Repositories
{
    public interface IUserAddressRepository : IDisposable
    {
        Task<int> Insert(UserAddress userAddress);
    }
}
