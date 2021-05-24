using ProductService.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Core.Interfaces.Repositories
{
    public interface ISubCategoryRepository : IDisposable
    {
        Task<List<Subcategory>> Filter(int? categoryId, string description);
    }
}
