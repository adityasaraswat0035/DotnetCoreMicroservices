using mango.integration.kafka.Configuration;
using mango.integration.kafka.Consumer;
using mango.order.api.Messages;
using mango.order.contracts.contracts;
using mango.order.contracts.dtos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.order.api.Consumers
{
    public class OrderProcessingService : KafkaConsumer<CheckoutHeaderDto>
    {
        private OrderManager orderManager;
        public OrderProcessingService(IOptions<KafkaConsumerConfiguration> options, OrderManager orderManagerFactory) : base(options)
        {
            orderManager = orderManagerFactory;
        }

        protected override string topicName { get => "OrderProcessing"; }

        protected override async Task ProcessMessage(CheckoutHeaderDto checkoutHeaderDto)
        {
            OrderHeaderDto orderHeader = new()
            {
                UserId = checkoutHeaderDto.UserId,
                Firstname = checkoutHeaderDto.Firstname,
                Lastname = checkoutHeaderDto.Lastname,
                OrderDetails = new List<OrderDetailsDto>(),
                CardNumber = checkoutHeaderDto.CardNumber,
                CouponCode = checkoutHeaderDto.CouponCode,
                CVV = checkoutHeaderDto.CVV,
                DiscountTotal = checkoutHeaderDto.discountTotal,
                Email = checkoutHeaderDto.Email,
                ExpiryMonthYear = checkoutHeaderDto.ExpiryMonthYear,
                OrderTime = DateTime.Now,
                OrderTotal = checkoutHeaderDto.CartTotal,
                PaymentStatus = false,
                Phone = checkoutHeaderDto.Phone,
                PickupDateTime = checkoutHeaderDto.PickupDateTime
            };
            foreach (var detailList in checkoutHeaderDto.CartDetails)
            {
                OrderDetailsDto orderDetails = new()
                {
                    ProductName = detailList.Product.Name,
                    Price = detailList.Product.Price,
                    Count = detailList.Count
                };
                orderHeader.TotalItems += detailList.Count;
                orderHeader.OrderDetails.Add(orderDetails);
            }
            await orderManager.AddOrder(orderHeader);
        }
    }
}
