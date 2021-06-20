using mango.coupon.repository.Entities;
using System.Threading.Tasks;

namespace mango.coupon.repository.repositories
{
    public interface CouponRepository
    {
        Task<Coupon> GetCouponByCodeAsync(string couponCode);
    }
}
