using AutoMapper;
using mango.coupon.repository.repositories;
using mango.order.contracts.contracts;
using System.Threading.Tasks;

namespace mango.coupon.manager
{
    public class OrderManagerImpl : OrderManager
    {
        private readonly OrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderManagerImpl(OrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
    }
}
