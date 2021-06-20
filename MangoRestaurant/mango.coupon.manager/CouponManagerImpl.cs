using AutoMapper;
using mango.coupon.contracts.contracts;
using mango.coupon.contracts.dtos;
using mango.coupon.repository.repositories;
using mango.infrstructure.common.Wrappers;
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

        public async Task<Optional<CouponDto>> GetCouponByCodeAsync(string couponCode)
        {
            var coupon =await couponRepository.GetCouponByCodeAsync(couponCode);
            if (coupon != null)
                return Optional<CouponDto>.Some(mapper.Map<CouponDto>(coupon));
            else
                return Optional<CouponDto>.None();
        }
    }
}
