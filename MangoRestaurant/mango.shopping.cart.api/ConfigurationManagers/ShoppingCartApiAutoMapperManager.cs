using mango.infrastructure.boilerplate.managers;
using mango.shopping.cart.manager.Mappers.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace mango.shopping.cart.api.ConfigurationManagers
{
    public class ShoppingCartApiAutoMapperManager : DefaultAutoMapperManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            //Auto Mapper Regsiteration
            services.AddSingleton(MapperConfig.RegisterMaps());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
