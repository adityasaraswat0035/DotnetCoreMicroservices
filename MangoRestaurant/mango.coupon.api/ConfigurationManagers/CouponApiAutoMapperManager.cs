using mango.coupon.manager.Mappers.Configurations;
using mango.infrastructure.boilerplate.managers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace mango.coupon.api.ConfigurationManagers
{
    public class CouponApiAutoMapperManager : DefaultAutoMapperManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            //Auto Mapper Regsiteration
            services.AddSingleton(MapperConfig.RegisterMaps());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
