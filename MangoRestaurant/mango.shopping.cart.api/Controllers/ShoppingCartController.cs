﻿using mango.shopping.cart.api.Controllers.Base;
using mango.shopping.cart.contracts.contracts;
using mango.shopping.cart.contracts.dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.shopping.cart.api.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartController : ApiBaseController
    {
        private readonly ShoppingCartManager shoppingCartManager;

        public ShoppingCartController(ShoppingCartManager shoppingCartManager)
        {
            this.shoppingCartManager = shoppingCartManager;
        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            return OptionalOK(await shoppingCartManager.GetCartByUserIdAsync(userId));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CartDto cartDto)
        {
            return Ok(await shoppingCartManager.CreateUpdateCartAsync(cartDto));
        }
        [HttpPut]
        public async Task<IActionResult> Put(CartDto cartDto)
        {
            return Ok(await shoppingCartManager.CreateUpdateCartAsync(cartDto));
        }
        [HttpDelete]
        [Route("{cartDetailId}")]
        public async Task<IActionResult> Delete(int cartDetailId)
        {
            return Ok(await shoppingCartManager.RemoveItemFromCartAsync(cartDetailId));
        }

        [HttpPost]
        [Route("coupon/apply")]
        public async Task<IActionResult> ApplyCoupon(CartDto cartDto)
        {
            return Ok(await shoppingCartManager.ApplyCouponOnCartAsync(cartDto.CartHeader.UserId, cartDto.CartHeader.CouponCode));
        }
        [HttpPost]
        [Route("coupon/remove")]
        public async Task<IActionResult> RemoveCoupon(CartDto cartDto)
        {
            return Ok(await shoppingCartManager.RemoveCouponOnCartAsync(cartDto.CartHeader.UserId));
        }
    }
}
