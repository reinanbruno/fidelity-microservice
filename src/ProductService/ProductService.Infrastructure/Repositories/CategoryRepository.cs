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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FidelityContext _dbContext;

        public CategoryRepository(FidelityContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        ~CategoryRepository() { Dispose(false); }

        void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        #endregion


        public async Task<List<Category>> Filter(string description)
        {
            IQueryable<Category> categories = _dbContext.Categories.Where(x => x.Active == 1);

            if (String.IsNullOrEmpty(description) == false)
            {
                categories = categories.Where(x => x.Name.Contains(description));
            }

            return await categories.OrderBy(x => x.Name).ToListAsync();

        }
    }
}
