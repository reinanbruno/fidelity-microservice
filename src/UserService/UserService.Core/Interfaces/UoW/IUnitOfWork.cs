using System;
using System.Threading.Tasks;

namespace UserService.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
