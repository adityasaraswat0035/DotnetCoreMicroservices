using mango.shopping.cart.contracts.contracts;
using mango.shopping.cart.repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace mango.shopping.cart.api.Infrastructure.Database
{
    public class DbInitializerImpl : DbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public DbInitializerImpl(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ShoppingCartDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ShoppingCartDbContext>())
                {
                    context.SaveChanges();
                }
            }
        }
    }
}
