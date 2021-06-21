using mango.infrstructure.common.Wrappers;
using mango.integration.kafka.Contract;
using mango.shopping.cart.api.Controllers.Base;
using mango.shopping.cart.api.Messages;
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
        private readonly IKafkaProducer producer;

        public ShoppingCartController(ShoppingCartManager shoppingCartManager, IKafkaProducer producer)
        {
            this.shoppingCartManager = shoppingCartManager;
            this.producer = producer;
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

        [HttpPost]
        [Route("checkout")]
        public async Task<IActionResult> Checkout(CheckoutHeaderDto checkoutHeaderDto)
        {
            try
            {
                Optional<CartDto> cartDto = await shoppingCartManager.GetCartByUserIdAsync(checkoutHeaderDto.UserId);
                if (cartDto.IsEmpty) return OptionalOK(cartDto);
                else
                {
                    checkoutHeaderDto.CartDetails = cartDto.Get().CartDetails; //now all properties to process the message
                                                                               //logic to Add Message for Processing ie. Async Point 
                    await producer.SendMessage("OrderProcessing", checkoutHeaderDto);
                    return Ok(true);
                }

            }
            catch (Exception ex)
            {
                //log exception here or transfer to shink like ELK
                return Ok(false);
            }
        }
    }
}
