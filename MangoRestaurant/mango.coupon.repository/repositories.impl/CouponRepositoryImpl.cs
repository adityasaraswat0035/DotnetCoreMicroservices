using mango.coupon.repository.DbContexts;
using mango.coupon.repository.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Coupon> GetCouponByCodeAsync(string couponCode)
        {
            return await couponDbContext.Coupons.FirstOrDefaultAsync(x => x.CouponCode == couponCode);
           
        }
    }
}
