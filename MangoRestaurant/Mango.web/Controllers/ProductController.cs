using mango.web.Configuration;
using mango.web.Contracts;
using mango.web.Services.Models;
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
        public ProductController(IProductService productService)
        {
            this.productService = productService;
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
    }
}
