using mango.infrastructure.boilerplate.managers;
using mango.shopping.cart.repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mango.shopping.cart.api.ConfigurationManagers
{
    public class ShoppingCartDbContextManager : DefaultDbContextManager
    {
        public override void ConfigureService(IServiceCollection services)
        {
            services.AddDbContext<ShoppingCartDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ShoppingCartApiDatabase")));
        }
    }
}
