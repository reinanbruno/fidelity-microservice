using UserService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UserService.Core.Interfaces.Repositories
{
    public interface IUserPointHistoryRepository : IDisposable
    {
        Task<List<UserPointHistory>> Filter(Expression<Func<UserPointHistory, bool>> func);
    }
}
