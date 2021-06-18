using mango.web.Configuration;
using mango.web.Services.Contracts;
using mango.web.Services.Models;
using mango.web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace mango.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto> productDtos = new List<ProductDto>();
            try
            {
                productDtos = await productService.GetProductAsync<List<ProductDto>>();

            }
            catch (Exception)
            {
                //log the error
            }
            return View(productDtos);
        }
        [HttpGet, HttpPost]
        public async Task<IActionResult> VerifyCategory(int Category)
        {
            var category = await categoryService.GetCategoryAsync<CategoryDto>(Category);
            if (category != null)
                return Json(true);
            else
                return Json("Category does not exits");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct([FromForm] ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var imageName = model.Image.FileName; //Process image and save it to AWS
                    ProductDto productDto = new ProductDto()
                    {
                        Category = new CategoryDto() { Id = model.Category },
                        Name = model.Name,
                        Description = model.Description,
                        Price = model.Price,
                        ImageUrl = imageName
                    };
                    productDto = await productService.CreateProductAsync<ProductDto>(productDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    model.Categories = await GetCategories();
                    return View(model);
                }
            }
            else
            {
                model.Categories = await GetCategories();
                return View(model);
            }
        }
        public async Task<IActionResult> CreateProduct()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Categories = await GetCategories();
            return View(productViewModel);

        }
        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            try
            {
                var categories = await categoryService.GetCategoryAsync<IEnumerable<CategoryDto>>();

                if (categories != null && categories.Any())
                {
                    return categories;
                }
                return Enumerable.Empty<CategoryDto>();
            }
            catch (Exception ex)
            {
                //log Exception
                return Enumerable.Empty<CategoryDto>();
            }
        }
    }
}
