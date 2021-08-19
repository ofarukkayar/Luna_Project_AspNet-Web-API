using AutoMapper;
using Luna_Project_AspNet_Web_API.Core.Models;
using Luna_Project_AspNet_Web_API.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luna_Project_AspNet_Web_API.Web.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto, Product>();

            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
        }
    }
}
