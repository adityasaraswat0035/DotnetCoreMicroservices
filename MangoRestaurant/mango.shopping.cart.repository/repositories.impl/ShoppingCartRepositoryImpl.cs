using mango.shopping.cart.repository.DbContexts;

namespace mango.shopping.cart.repository.repositories.impl
{
    public class ShoppingCartRepositoryImpl : ShoppingCartRepository
    {
        private readonly ShoppingCartDbContext productDbContext;

        public ShoppingCartRepositoryImpl(ShoppingCartDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }
    }
}
