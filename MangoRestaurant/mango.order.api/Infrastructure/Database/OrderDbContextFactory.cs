using mango.order.api.db;
using mango.order.repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace mango.coupon.api.Infrastructure.Database
{
    public class OrderDbContextFactory : IDesignTimeDbContextFactory<OrderDbContext>
    {
        public OrderDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=MangoOrderApi;Trusted_Connection=true;MultipleActiveResultSets=true",
             sqlOptions =>
             {
                 sqlOptions.MigrationsAssembly(typeof(OrderApiDatabaseMigration).Assembly.FullName);
             });

            return new OrderDbContext(optionsBuilder.Options);
        }
    }
}
