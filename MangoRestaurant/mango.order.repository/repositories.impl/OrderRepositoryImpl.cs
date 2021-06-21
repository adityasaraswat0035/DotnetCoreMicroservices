using mango.order.repository.DbContexts;
using mango.order.repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace mango.coupon.repository.repositories.impl
{
    public class OrderRepositoryImpl : OrderRepository
    {
        // private readonly DbContextOptions<OrderDbContext> contextOptions;
        private readonly DbContextOptions<OrderDbContext> dbContextOptions;

        public OrderRepositoryImpl(DbContextOptions<OrderDbContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public async Task<bool> AddOrder(OrderHeader orderHeader)
        {
            await using var orderDbContext = new OrderDbContext(dbContextOptions);
            orderDbContext.OrderHeaders.Add(orderHeader);
            await orderDbContext.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid)
        {
            await using var orderDbContext = new OrderDbContext(dbContextOptions);
            var orderHeader = await orderDbContext.OrderHeaders.FirstOrDefaultAsync(x => x.Id == orderHeaderId);
            if (orderHeader != null)
            {
                orderHeader.PaymentStatus = paid;
                await orderDbContext.SaveChangesAsync();
            }
        }
    }
}
