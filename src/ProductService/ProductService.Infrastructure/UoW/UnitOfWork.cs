using ProductService.Core.Interfaces;
using ProductService.Infrastructure.Context;
using System;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly FidelityContext _context;

        public UnitOfWork(FidelityContext context)
        {
            _context = context;
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        ~UnitOfWork() { Dispose(false); }

        void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        #endregion

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
