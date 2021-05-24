using ProductService.Core.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.Core.Interfaces.Repositories
{
    public interface IUserRepository : IDisposable
    {
        Task<User> Find(Expression<Func<User, bool>> func);
        Task Update(User user);
    }
}
