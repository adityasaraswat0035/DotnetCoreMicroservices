using mango.coupon.contracts.dtos;
using mango.infrstructure.common.Wrappers;
using System.Threading.Tasks;

namespace mango.coupon.contracts.contracts
{
    public interface CouponManager
    {
        Task<Optional<CouponDto>> GetCouponByCodeAsync(string couponCode);
    }
}
