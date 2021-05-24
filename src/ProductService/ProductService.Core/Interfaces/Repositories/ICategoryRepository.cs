using ProductService.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : IDisposable
    {
        Task<List<Category>> Filter(string description);
    }
}
