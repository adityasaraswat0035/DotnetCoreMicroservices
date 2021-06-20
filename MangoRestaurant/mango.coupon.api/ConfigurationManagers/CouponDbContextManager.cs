using mango.coupon.repository.DbContexts;
using mango.infrastructure.boilerplate.managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mango.coupon.api.ConfigurationManagers
{
    public class CouponDbContextManager : DefaultDbContextManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            services.AddDbContext<CouponDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CouponApiDatabase")));
        }
    }
}
