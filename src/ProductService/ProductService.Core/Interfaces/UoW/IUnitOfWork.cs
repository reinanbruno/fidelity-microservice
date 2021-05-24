using System;
using System.Threading.Tasks;

namespace ProductService.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
