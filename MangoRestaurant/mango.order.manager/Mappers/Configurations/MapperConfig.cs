using AutoMapper;

namespace mango.order.manager.Mappers.Configurations
{
    public class MapperConfig
    {
        public static IMapper RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configure =>
            {
                //configure.CreateMap<CouponDto, Coupon>().ReverseMap();
            });
            return mappingConfig.CreateMapper(); ;
        }
    }
}
