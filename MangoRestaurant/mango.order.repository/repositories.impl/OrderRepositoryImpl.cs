using mango.order.repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace mango.coupon.repository.repositories.impl
{
    public class OrderRepositoryImpl : OrderRepository
    {
        private readonly OrderDbContext couponDbContext;

        public OrderRepositoryImpl(OrderDbContext shoppingCartDb)
        {
            couponDbContext = shoppingCartDb;
        }

    }
}
