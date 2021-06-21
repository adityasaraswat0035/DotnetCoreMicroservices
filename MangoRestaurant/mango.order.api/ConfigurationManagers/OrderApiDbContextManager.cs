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
        }
    }
}
