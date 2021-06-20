using AutoMapper;
using mango.coupon.contracts.dtos;
using mango.coupon.repository.Entities;

namespace mango.coupon.manager.Mappers.Configurations
{
    public class MapperConfig
    {
        public static IMapper RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configure =>
            {
                configure.CreateMap<CouponDto, Coupon>().ReverseMap();
            });
            return mappingConfig.CreateMapper(); ;
        }
    }
}
