using mango.web.Configuration;
using mango.web.Services.Contracts;
using mango.web.Services.Models;
using mango.web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
                productDtos = await productService.GetProductAsync<List<ProductDto>>(await HttpContext.GetTokenAsync("access_token"));

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
            var category = await categoryService.GetCategoryAsync<CategoryDto>(Category,await HttpContext.GetTokenAsync("access_token"));
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
                    productDto = await productService.CreateProductAsync<ProductDto>(productDto, await HttpContext.GetTokenAsync("access_token"));
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
                var categories = await categoryService.GetCategoryAsync<IEnumerable<CategoryDto>>(await HttpContext.GetTokenAsync("access_token"));

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

        public async Task<IActionResult> EditProduct(int productId)
        {
            ProductDto productDto = await productService.GetProductAsync<ProductDto>(productId, await HttpContext.GetTokenAsync("access_token"));
            if (productDto != null)
            {
                ProductViewModel productViewModel = new ProductViewModel()
                {
                    Id = productDto.Id,
                    Category = productDto.Category.Id,
                    Categories = await GetCategories(),
                    Description = productDto.Description,
                    Name = productDto.Name,
                    Price = productDto.Price,
                };
                return View(productViewModel);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var imageName = model.Image.FileName; //Process image and save it to AWS
                    ProductDto productDto = new ProductDto()
                    {
                        Id = model.Id,
                        Category = new CategoryDto() { Id = model.Category },
                        Name = model.Name,
                        Description = model.Description,
                        Price = model.Price,
                        ImageUrl = imageName
                    };
                    productDto = await productService.CreateProductAsync<ProductDto>(productDto, await HttpContext.GetTokenAsync("access_token"));
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
        [Authorize(Roles ="Admin")]

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            ProductDto productDto = await productService.GetProductAsync<ProductDto>(productId, await HttpContext.GetTokenAsync("access_token"));
            if (productDto != null)
            {
                ProductViewModel productViewModel = new ProductViewModel()
                {
                    Id = productDto.Id,
                    Category = productDto.Category.Id,
                    Categories = await GetCategories(),
                    Description = productDto.Description,
                    Name = productDto.Name,
                    Price = productDto.Price,
                };
                return View(productViewModel);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(ProductViewModel model)
        {
            try
            {
                int productId = model.Id;
                _ = await productService.DeleteProductAsync<ProductDto>(productId, await HttpContext.GetTokenAsync("access_token"));
            }
            catch (Exception ex)
            {
                //logg execption 
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
