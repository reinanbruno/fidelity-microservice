using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using ProductService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly FidelityContext _dbContext;

        public ProductRepository(FidelityContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        ~ProductRepository() { Dispose(false); }

        void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        #endregion
        public async Task<Product> Find(Expression<Func<Product, bool>> func)
        {
            return await _dbContext.Products.Where(func).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> Filter(int? categoryId, int? subcategoryId)
        {
            IQueryable<Product> products = _dbContext.Products
                                                     .Include(x => x.Subcategory)
                                                     .ThenInclude(x => x.Category)
                                                     .Where(x => x.Active == 1 &&
                                                                 x.Subcategory.Active == 1 &&
                                                                 x.Subcategory.Category.Active == 1);

            if (categoryId != null)
            {
                products = products.Where(x => x.Subcategory.CategoryId == categoryId);
            }

            if (subcategoryId != null)
            {
                products = products.Where(x => x.SubcategoryId == subcategoryId);
            }

            return await products.OrderBy(x => x.Name).ToListAsync();

        }
    }
}
