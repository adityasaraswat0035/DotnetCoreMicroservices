using mango.order.contracts.dtos;
using System.Threading.Tasks;

namespace mango.order.contracts.contracts
{
    public interface OrderManager
    {
        Task<bool> AddOrder(OrderHeaderDto orderHeaderDto);
    }
}
