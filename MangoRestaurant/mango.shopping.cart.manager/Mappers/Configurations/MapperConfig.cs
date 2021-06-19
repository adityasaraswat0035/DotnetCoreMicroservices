using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.shopping.cart.manager.Mappers.Configurations
{
    public class MapperConfig
    {
        public static IMapper RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configure =>
            {

            });
            return mappingConfig.CreateMapper(); ;
        }
    }
}
