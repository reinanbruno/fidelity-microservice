using ProductService.Core.Interfaces;
using System.Threading.Tasks;

namespace ProductService.Test.UoW
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
