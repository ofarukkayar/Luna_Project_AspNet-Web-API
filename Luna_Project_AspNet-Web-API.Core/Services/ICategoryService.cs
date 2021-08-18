using Luna_Project_AspNet_Web_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luna_Project_AspNet_Web_API.Core.Services
{
    public interface ICategoryService :IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

        // All methods that are unique in Category interface could be defined here.
    }
}
