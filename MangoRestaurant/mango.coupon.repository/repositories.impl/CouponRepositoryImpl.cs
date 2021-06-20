using mango.coupon.repository.DbContexts;
using mango.coupon.repository.repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace mango.coupon.repository.repositories.impl
{
    public class CouponRepositoryImpl : CouponRepository
    {
        private readonly CouponDbContext couponDbContext;

        public CouponRepositoryImpl(CouponDbContext shoppingCartDb)
        {
            couponDbContext = shoppingCartDb;
        }
    }
}
