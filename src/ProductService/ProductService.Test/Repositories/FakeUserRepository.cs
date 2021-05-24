using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.Test.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public FakeUserRepository()
        {
            _users.Add(new User
            {
                UserId = 1,
                Name = "Teste1",
                Password = "123456",
                IndividualTaxpayerRegistration = "86872498021",
                Email = "t1@gmail.com",
                Active = 1,
                CurrentPointsBalance = 10,
                UserAddresses = new List<UserAddress>() { new UserAddress { UserAddressId = 1 } }
            });
            _users.Add(new User
            {
                UserId = 2,
                Name = "Teste2",
                Password = "123456",
                IndividualTaxpayerRegistration = "90144123045",
                Email = "t2@gmail.com",
                Active = 1,
                CurrentPointsBalance = 16,
                UserAddresses = new List<UserAddress>() { new UserAddress { UserAddressId = 2 } }
            });
            _users.Add(new User
            {
                UserId = 3,
                Name = "Teste3",
                Password = "123456",
                IndividualTaxpayerRegistration = "82898427080",
                Email = "t3@gmail.com",
                Active = 0,
                CurrentPointsBalance = 15,
                UserAddresses = new List<UserAddress>() { new UserAddress { UserAddressId = 3 } }
            });
        }

        public void Dispose() { }

        public async Task<User> Find(Expression<Func<User, bool>> func)
        {
            return _users.Where(func.Compile()).FirstOrDefault();
        }

        public async Task Update(User user) { }
    }
}
