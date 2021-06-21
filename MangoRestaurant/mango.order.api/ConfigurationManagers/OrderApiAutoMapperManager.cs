using mango.infrastructure.boilerplate.managers;
using mango.order.manager.Mappers.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace mango.order.api.ConfigurationManagers
{
    public class OrderApiAutoMapperManager : DefaultAutoMapperManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            //Auto Mapper Regsiteration
            services.AddSingleton(MapperConfig.RegisterMaps());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
