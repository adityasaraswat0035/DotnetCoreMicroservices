using mango.product.api.db;
using mango.product.repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.product.api.Infrastructure.DbContext
{
    public class ProductDbContextFactory : IDesignTimeDbContextFactory<ProductDbContext>
    {
        public ProductDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductDbContext>();
             optionsBuilder.UseSqlServer("Server=localhost;Database=MangoProductApi;Trusted_Connection=true;MultipleActiveResultSets=true",
              sqlOptions =>
              {
                  sqlOptions.MigrationsAssembly(typeof(ProductApiDatabaseMigration).Assembly.FullName);
              });

            return new ProductDbContext(optionsBuilder.Options);
        }
    }
}
