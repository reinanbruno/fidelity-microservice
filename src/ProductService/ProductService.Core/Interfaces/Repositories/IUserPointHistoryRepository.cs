using ProductService.Core.Models;
using System;
using System.Threading.Tasks;

namespace ProductService.Core.Interfaces.Repositories
{
    public interface IUserPointHistoryRepository : IDisposable
    {
        Task Insert(UserPointHistory userPointHistory);
    }
}
