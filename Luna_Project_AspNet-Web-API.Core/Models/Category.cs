using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Luna_Project_AspNet_Web_API.Core.Models
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
