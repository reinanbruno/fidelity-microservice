using UserService.Core.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UserService.Core.Interfaces.Repositories
{
    public interface IUserRepository : IDisposable
    {
        Task<int> Insert(User user);
        Task<User> Find(Expression<Func<User, bool>> func);
        Task<decimal> GetPointsBalance(int userId);

    }
}
