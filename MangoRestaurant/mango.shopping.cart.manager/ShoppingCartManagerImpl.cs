using AutoMapper;
using mango.shopping.cart.contracts.contracts;
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
    }
}
