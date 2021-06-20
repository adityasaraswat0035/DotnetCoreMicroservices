using AutoMapper;
using mango.shopping.cart.contracts.contracts;
using mango.shopping.cart.contracts.dtos;
using mango.shopping.cart.repository.NonEntities;
using mango.shopping.cart.repository.repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mango.shopping.cart.manager
{
    public class ShoppingCartManagerImpl : ShoppingCartManager
    {
        private readonly ShoppingCartRepository shoppingCartRepository;
        private readonly IMapper mapper;

        public ShoppingCartManagerImpl(ShoppingCartRepository shoppingCartRepository, IMapper mapper)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.mapper = mapper;
        }

        public async Task<bool> ClearCartAsync(string userId)
        {
            return await shoppingCartRepository.ClearCartAsync(userId);
        }

        public async Task<CartDto> CreateUpdateCartAsync(CartDto cartDto)
        {
            var cart = mapper.Map<Cart>(cartDto);
            cart = await shoppingCartRepository.CreateUpdateCartAsync(cart);
            return mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> GetCartByUserIdAsync(string userId)
        {
            var cart = await shoppingCartRepository.GetCartByUserIdAsync(userId);
            return mapper.Map<CartDto>(cart);
        }

        public async Task<bool> RemoveItemFromCartAsync(int CartDetailsId)
        {
            return await shoppingCartRepository.RemoveItemFromCartAsync(CartDetailsId);
        }
    }
}
