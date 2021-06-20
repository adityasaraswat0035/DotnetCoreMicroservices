using mango.web.Services.Contracts;
using mango.web.Services.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductService productService;
        private readonly ICartService cartService;

        public CartController(IProductService productService, ICartService cartService)
        {
            this.productService = productService;
            this.cartService = cartService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await LoadCartDtoByUser());
        }

        public async Task<IActionResult> RemoveItem(int cartDetailId)
        {
            var userId = User.Claims.Where(u => u.Type == "sub").FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var result = await cartService.RemoveFromCartAsync<bool>(cartDetailId, accessToken);
            if (result)return RedirectToAction(nameof(Index));
            return View();
        }

        private async Task<CartDto> LoadCartDtoByUser()
        {
            try
            {

                var userId = User.Claims.Where(u => u.Type == "sub").FirstOrDefault()?.Value;
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var cart = await cartService.GetCartByUserIdAsync<CartDto>(userId, accessToken);
                if (cart != null && cart.CartHeader != null)
                {
                    foreach (var cartDetail in cart.CartDetails)
                    {
                        cart.CartHeader.CartTotal = cartDetail.Product.Price * cartDetail.Count + cart.CartHeader.CartTotal;
                    }
                    return cart;
                }
                else
                {
                    return new CartDto();
                }
            }
            catch (Exception ex)
            {
                //log the exception
                return new CartDto();
            }
        }
    }
}
