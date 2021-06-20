using AutoMapper;

namespace mango.coupon.manager.Mappers.Configurations
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
