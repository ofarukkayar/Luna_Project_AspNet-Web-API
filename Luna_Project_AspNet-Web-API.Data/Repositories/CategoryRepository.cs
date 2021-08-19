using Luna_Project_AspNet_Web_API.Core.Models;
using Luna_Project_AspNet_Web_API.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luna_Project_AspNet_Web_API.Data.Repositories
{
    class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get; }
        public CategoryRepository(AppDbContext context): base(context)
        {

        }
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x=>x.Id == categoryId);
        }
    }
}
