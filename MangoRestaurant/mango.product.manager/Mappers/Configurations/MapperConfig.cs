using AutoMapper;
using mango.product.contracts.dtos;
using mango.product.repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mango.product.manager.Mappers.Configurations
{
    public class MapperConfig
    {
        public static IMapper RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configure =>
            {
                configure.CreateMap<ProductDto, Product>().ReverseMap();
                configure.CreateMap<CategoryDto, Category>().ReverseMap();
            });
            return mappingConfig.CreateMapper(); ;
        }
    }
}
