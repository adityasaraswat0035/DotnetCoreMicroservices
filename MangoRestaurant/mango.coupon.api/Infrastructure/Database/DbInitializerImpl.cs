using mango.coupon.contracts.contracts;
using mango.coupon.repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

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
        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<CouponDbContext>())
                {
                    //if (!context.Categories.Any())
                    //{
                    //    context.SaveChanges();
                    //}
                }
            }
        }
    }
}
