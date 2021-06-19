using mango.product.api.db;
using mango.shopping.cart.repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace mango.shopping.cart.api.Infrastructure.Database
{
    public class ShoppingCartDbContextFactory : IDesignTimeDbContextFactory<ShoppingCartDbContext>
    {
        public ShoppingCartDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShoppingCartDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=MangoProductApi;Trusted_Connection=true;MultipleActiveResultSets=true",
             sqlOptions =>
             {
                 sqlOptions.MigrationsAssembly(typeof(ShoppingCartApiDatabaseMigration).Assembly.FullName);
             });

            return new ShoppingCartDbContext(optionsBuilder.Options);
        }
    }
}
