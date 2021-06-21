using AutoMapper;
using mango.order.contracts.dtos;
using mango.order.repository.Entities;

namespace mango.order.manager.Mappers.Configurations
{
    public class MapperConfig
    {
        public static IMapper RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configure =>
            {
                configure.CreateMap<OrderDetailsDto, OrderDetails>().ReverseMap();
                configure.CreateMap<OrderHeaderDto, OrderHeader>().ReverseMap();
            });
            return mappingConfig.CreateMapper(); ;
        }
    }
}
