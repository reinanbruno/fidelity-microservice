using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using System.Threading.Tasks;

namespace ProductService.Test.Repositories
{
    public class FakeUserPointHistoryRepository : IUserPointHistoryRepository
    {
        public void Dispose(){}

        public Task Insert(UserPointHistory userPointHistory)
        {
            return Task.FromResult(true);
        }
    }
}
