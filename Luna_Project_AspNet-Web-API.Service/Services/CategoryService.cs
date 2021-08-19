using Luna_Project_AspNet_Web_API.Core.Models;
using Luna_Project_AspNet_Web_API.Core.Repositories;
using Luna_Project_AspNet_Web_API.Core.Services;
using Luna_Project_AspNet_Web_API.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luna_Project_AspNet_Web_API.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
