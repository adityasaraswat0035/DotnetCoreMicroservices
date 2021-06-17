using mango.infrastructure.boilerplate.managers;
using mango.product.api.db;
using mango.product.repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.product.api.ConfigurationManagers
{
    public class ProductDbContextManager : DefaultDbContextManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ProductApiDatabase")));
        }
    }
}
