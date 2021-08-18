using Luna_Project_AspNet_Web_API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luna_Project_AspNet_Web_API.Data.Seeds
{
    class ProductSeed:IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Needle Pen", Price = 20.00m, Stock = 50, CategoryId = _ids[0] },
                new Product { Id = 2, Name = "Leed Pencil", Price = 5.00m, Stock = 200, CategoryId = _ids[0] },
                new Product { Id = 3, Name = "Pen", Price = 12.50m, Stock = 150, CategoryId = _ids[0] },
                new Product { Id = 4, Name = "Small Size Notebook", Price = 15.00m, Stock = 70, CategoryId = _ids[1] },
                new Product { Id = 5, Name = "Medium Size Notebook", Price = 25.00m, Stock = 60, CategoryId = _ids[1] },
                new Product { Id = 6, Name = "Large Size Notebook", Price = 35.00m, Stock = 90, CategoryId = _ids[1] }
                );
        }
    }
}
