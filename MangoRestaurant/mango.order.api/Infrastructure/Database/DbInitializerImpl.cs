using mango.order.contracts.contracts;
using mango.order.repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace mango.order.api.Infrastructure.Database
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
                using (var context = serviceScope.ServiceProvider.GetService<OrderDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
        public async void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<OrderDbContext>())
                {
                   
                }
            }
        }
    }
}
