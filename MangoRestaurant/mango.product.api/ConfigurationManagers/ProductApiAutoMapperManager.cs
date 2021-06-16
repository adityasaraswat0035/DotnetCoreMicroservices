using mango.infrastructure.boilerplate.managers;
using mango.product.manager.Mappers.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.product.api.ConfigurationManagers
{
    public class ProductApiAutoMapperManager : DefaultAutoMapperManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            //Auto Mapper Regsiteration
            services.AddSingleton(MapperConfig.RegisterMaps());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
