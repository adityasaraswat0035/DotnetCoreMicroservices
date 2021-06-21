using mango.coupon.repository.repositories;
using mango.coupon.repository.repositories.impl;
using mango.infrastructure.boilerplate.managers;
using mango.order.repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mango.order.api.ConfigurationManagers
{
    public class OrderApiDbContextManager : DefaultDbContextManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            services.AddDbContext<OrderDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("OrderApiDatabase")));

            //When We pass OrderDBContext as DbContextOptions<OrderDbContext> as dependency e.g. for Azure
            //var optionBuilder = new DbContextOptionsBuilder<OrderDbContext>();
            //optionBuilder.UseSqlServer(Configuration.GetConnectionString("OrderApiDatabase"));
            //var orderRepoImpl = new OrderRepositoryImpl(optionBuilder.Options);
            //services.AddSingleton(typeof(OrderRepository), orderRepoImpl);
        }
    }
}
