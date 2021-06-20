using AutoMapper;
using mango.coupon.contracts.contracts;
using mango.coupon.repository.repositories;
using System.Threading.Tasks;

namespace mango.coupon.manager
{
    public class CouponManagerImpl : CouponManager
    {
        private readonly CouponRepository couponRepository;
        private readonly IMapper mapper;

        public CouponManagerImpl(CouponRepository couponRepository, IMapper mapper)
        {
            this.couponRepository = couponRepository;
            this.mapper = mapper;
        }
    }
}
