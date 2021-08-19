using AutoMapper;
using Luna_Project_AspNet_Web_API.Core.Models;
using Luna_Project_AspNet_Web_API.Core.Services;
using Luna_Project_AspNet_Web_API.Web.DTOs;
using Luna_Project_AspNet_Web_API.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luna_Project_AspNet_Web_API.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]

        public IActionResult Update(CategoryDto categoryDto)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDto));

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;

            _categoryService.Remove(category);

            return RedirectToAction("Index");   
        }

    }
}
