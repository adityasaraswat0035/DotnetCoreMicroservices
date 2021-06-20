using mango.coupon.contracts.contracts;
using mango.coupon.repository.DbContexts;
using mango.coupon.repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace mango.coupon.api.Infrastructure.Database
{
    public class DbInitializerImpl : DbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public DbInitializerImpl(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<CouponDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
        public async void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<CouponDbContext>())
                {
                    if (!context.Coupons.Any())
                    {
                        context.Coupons.Add(new Coupon() { CouponCode = "10OFF", DiscountAmount = 10 });
                        context.Coupons.Add(new Coupon() { CouponCode = "20OFF", DiscountAmount = 20 });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
