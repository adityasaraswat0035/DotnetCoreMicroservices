using mango.order.repository.Entities;
using System.Threading.Tasks;

namespace mango.coupon.repository.repositories
{
    public interface OrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);
        Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid);
    }
}
