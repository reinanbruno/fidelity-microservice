using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using ProductService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly FidelityContext _dbContext;

        public SubCategoryRepository(FidelityContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        ~SubCategoryRepository() { Dispose(false); }

        void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        #endregion


        public async Task<List<Subcategory>> Filter(int? categoryId, string description)
        {
            IQueryable<Subcategory> subCategories = _dbContext.Subcategories
                                                              .Include(x => x.Category)
                                                              .Where(x => x.Active == 1);

            if (String.IsNullOrEmpty(description) == false)
            {
                subCategories = subCategories.Where(x => x.Name.Contains(description));
            }

            if(categoryId != null)
            {
                subCategories = subCategories.Where(x => x.Category.CategoryId == categoryId);
            }

            return await subCategories.OrderBy(x => x.Name).ToListAsync();

        }
    }
}
