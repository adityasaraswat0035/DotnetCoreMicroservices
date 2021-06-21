using mango.coupon.manager;
using mango.infrastructure.boilerplate.managers;
using mango.order.contracts.contracts;
using Microsoft.Extensions.DependencyInjection;
using mango.coupon.repository.repositories;
using mango.coupon.repository.repositories.impl;

namespace mango.order.api.ConfigurationManagers
{
    public class OrderApiServicesManager : DefaultApplicationServicesManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<OrderManager, OrderManagerImpl>();
            services.AddScoped<OrderRepository, OrderRepositoryImpl>();

        }
    }
}
