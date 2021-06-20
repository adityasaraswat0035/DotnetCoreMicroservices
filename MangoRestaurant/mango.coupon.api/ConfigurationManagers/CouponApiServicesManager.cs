using mango.coupon.contracts.contracts;
using mango.coupon.manager;
using mango.coupon.repository.repositories;
using mango.coupon.repository.repositories.impl;
using mango.infrastructure.boilerplate.managers;
using Microsoft.Extensions.DependencyInjection;

namespace mango.coupon.api.ConfigurationManagers
{
    public class CouponApiServicesManager : DefaultApplicationServicesManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<CouponManager, CouponManagerImpl>();
            services.AddScoped<CouponRepository, CouponRepositoryImpl>();

        }
    }
}
