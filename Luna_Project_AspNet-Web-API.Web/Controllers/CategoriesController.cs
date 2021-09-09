using AutoMapper;
using Luna_Project_AspNet_Web_API.Web.ApiService;
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
        private readonly IMapper _mapper;
        private readonly CategoryApiService _categoryApiService;

        public CategoriesController(IMapper mapper, CategoryApiService categoryApiService)
        {
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryApiService.AddAsync(categoryDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryApiService.Update(categoryDto);

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryApiService.Remove(id);

            return RedirectToAction("Index");   
        }

    }
}
