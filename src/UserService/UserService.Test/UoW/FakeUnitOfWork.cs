using System.Threading.Tasks;
using UserService.Core.Interfaces;

namespace UserService.Test.UoW
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public Task<bool> Commit()
        {
            return Task.FromResult(true);
        }

        public void Dispose()
        {
        }
    }
}
