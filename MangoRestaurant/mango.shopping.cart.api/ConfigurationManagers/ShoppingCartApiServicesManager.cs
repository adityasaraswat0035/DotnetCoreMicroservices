using mango.infrastructure.boilerplate.managers;
using mango.shopping.cart.contracts.contracts;
using mango.shopping.cart.manager;
using mango.shopping.cart.repository.repositories;
using mango.shopping.cart.repository.repositories.impl;
using Microsoft.Extensions.DependencyInjection;

namespace mango.shopping.cart.api.ConfigurationManagers
{
    public class ShoppingCartApiServicesManager: DefaultApplicationServicesManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<ShoppingCartManager, ShoppingCartManagerImpl>();
            services.AddScoped<ShoppingCartRepository, ShoppingCartRepositoryImpl>();

        }
    }
}
