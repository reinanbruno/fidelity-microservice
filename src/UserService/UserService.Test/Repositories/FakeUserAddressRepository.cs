using UserService.Core.Interfaces.Repositories;
using UserService.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserService.Test.Repositories
{
    public class FakeUserAddressRepository : IUserAddressRepository
    {
        private readonly List<UserAddress> _usersAddress = new List<UserAddress>();

        public FakeUserAddressRepository()
        {
            _usersAddress.Add(new UserAddress { UserAddressId = 1, UserId = 1, Address = "Rua 1", City = "Salvador", State = "BA", District = "Barra", Active = 1 });
            _usersAddress.Add(new UserAddress { UserAddressId = 2, UserId = 5, Address = "Rua 2", City = "Salvador", State = "BA", District = "Barra", Active = 1 });
            _usersAddress.Add(new UserAddress { UserAddressId = 3, UserId = 2, Address = "Rua 3", City = "Salvador", State = "BA", District = "Barra", Active = 1 });
        }

        public void Dispose(){}

        public async Task<int> Insert(UserAddress userAddress)
        {
            return userAddress.UserAddressId;
        }
    }
}
