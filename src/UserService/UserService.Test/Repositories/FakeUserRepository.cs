using UserService.Core.Interfaces.Repositories;
using UserService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UserService.Test.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public FakeUserRepository()
        {
            _users.Add(new User { UserId = 1, Name = "Teste1", Password = "123456", IndividualTaxpayerRegistration = "86872498021", Email = "t1@gmail.com", Active = 1, CurrentPointsBalance = 50 });
            _users.Add(new User { UserId = 2, Name = "Teste2", Password = "123456", IndividualTaxpayerRegistration = "90144123045", Email = "t2@gmail.com", Active = 1, CurrentPointsBalance = 23 });
            _users.Add(new User { UserId = 3, Name = "Teste3", Password = "123456", IndividualTaxpayerRegistration = "82898427080", Email = "t3@gmail.com", Active = 0, CurrentPointsBalance = 35 });
        }

        public void Dispose() { }

        public async Task<User> Find(Expression<Func<User, bool>> func)
        {
            return _users.Where(func.Compile()).FirstOrDefault();
        }

        public async Task<decimal> GetPointsBalance(int userId)
        {
            return _users.Where(x => x.UserId == userId).Sum(x => x.CurrentPointsBalance);
        }

        public async Task<int> Insert(User user)
        {
            return user.UserId;
        }
    }
}
