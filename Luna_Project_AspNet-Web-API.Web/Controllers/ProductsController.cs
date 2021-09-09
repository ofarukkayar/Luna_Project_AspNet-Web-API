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
    public class ProductsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ProductApiService _productApiService;

        public ProductsController(IMapper mapper, ProductApiService productApiService)
        {
            _mapper = mapper;
            _productApiService = productApiService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await _productApiService.AddAsync(productDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);
            return View(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _productApiService.Update(productDto);

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(ProductNotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _productApiService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
