using AutoMapper;
using mango.coupon.repository.repositories;
using mango.order.contracts.contracts;
using mango.order.contracts.dtos;
using mango.order.repository.Entities;
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

        public async Task<bool> AddOrder(OrderHeaderDto orderHeaderDto)
        {
            try
            {
                var order = mapper.Map<OrderHeader>(orderHeaderDto);
                return await orderRepository.AddOrder(order);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
