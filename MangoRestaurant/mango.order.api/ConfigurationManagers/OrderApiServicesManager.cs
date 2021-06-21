using mango.coupon.manager;
using mango.infrastructure.boilerplate.managers;
using mango.order.contracts.contracts;
using Microsoft.Extensions.DependencyInjection;
using mango.coupon.repository.repositories;
using mango.coupon.repository.repositories.impl;
using System;
using mango.order.api.Consumers;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using mango.order.repository.DbContexts;

namespace mango.order.api.ConfigurationManagers
{
    public class OrderApiServicesManager : DefaultApplicationServicesManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            var optionBuilder = new DbContextOptionsBuilder<OrderDbContext>().UseSqlServer(Configuration.GetConnectionString("OrderApiDatabase"));
            OrderRepository orderRepository = new OrderRepositoryImpl(optionBuilder.Options);
            services.AddSingleton(orderRepository);
            services.AddSingleton<OrderManager, OrderManagerImpl>();
            services.AddHostedService<OrderProcessingService>();
        }
    }
}
