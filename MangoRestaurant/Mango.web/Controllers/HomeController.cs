using mango.shopping.cart.contracts.dtos;
using mango.web.Services.Contracts;
using mango.web.Services.Models;
using Mango.web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly ICartService cartService;

        public HomeController(ILogger<HomeController> logger, IProductService productService,ICartService cartService)
        {
            _logger = logger;
            this.productService = productService;
            this.cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto> list = new List<ProductDto>();
            list = await productService.GetProductAsync<List<ProductDto>>(await HttpContext.GetTokenAsync("access_token"));
            return View(list);
        }
        [Authorize]
        public async Task<IActionResult> Details(int proudctId)
        {
            ProductDto product = new ProductDto();
            product = await productService.GetProductAsync<ProductDto>(proudctId, await HttpContext.GetTokenAsync("access_token"));
            return View(product);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddItemToCart(ProductDto productDto)
        {
            try
            {
                CartDto cartDto = new()
                {
                    CartHeader = new CartHeaderDto
                    {
                        UserId = User.Claims.Where(x => x.Type == "sub").FirstOrDefault()?.Value
                    }
                };
                CartDetailDto cartDetailDto = new CartDetailDto
                {
                    Count = productDto.Count,
                    ProductId = productDto.Id
                };
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                ProductDto product = await productService.GetProductAsync<ProductDto>(productDto.Id, accessToken);
                cartDetailDto.Product = new ProductDto()
                {
                    Id = product.Id,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.Name,
                    ImageUrl = product.ImageUrl
                };

                cartDto.CartDetails = new List<CartDetailDto> { cartDetailDto };
                var addToCart = await cartService.AddToCartAsync<CartDto>(cartDto, accessToken);
                if (addToCart != null) return RedirectToAction(nameof(Index));
                else return View(productDto);
            }
            catch (Exception)
            {
                return View(productDto);
            }

        }


        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult LogOut()
        {
            return SignOut(CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
