using mango.infrastructure.boilerplate.managers;
using mango.product.contract.contracts;
using mango.product.manager;
using mango.product.repository.repositories;
using mango.product.repository.repositories.impl;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.product.api.ConfigurationManagers
{
    public class ProductApiServicesManager: DefaultApplicationServicesManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<ProductRepository, ProductRepositoryImpl>();
            services.AddScoped<ProductManager, ProductManagerImpl>();
        }
    }
}
