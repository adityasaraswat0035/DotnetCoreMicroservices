using AutoMapper;
using mango.shopping.cart.contracts.dtos;
using mango.shopping.cart.repository.Entities;
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
                configure.CreateMap<ProductDto, Product>().ReverseMap();
                configure.CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
                configure.CreateMap<CartDetailDto, CartDetail>().ReverseMap();
                configure.CreateMap<CartDto, CartDto>().ReverseMap();
            });
            return mappingConfig.CreateMapper(); ;
        }
    }
}
