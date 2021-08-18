using Luna_Project_AspNet_Web_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luna_Project_AspNet_Web_API.Core.Repositories
{
    interface ICategoryRepository:IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

    }
}
