using mango.coupon.api.db;
using mango.coupon.repository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace mango.coupon.api.Infrastructure.Database
{
    public class CouponDbContextFactory : IDesignTimeDbContextFactory<CouponDbContext>
    {
        public CouponDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CouponDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=MangoCouponApi;Trusted_Connection=true;MultipleActiveResultSets=true",
             sqlOptions =>
             {
                 sqlOptions.MigrationsAssembly(typeof(CouponApiDatabaseMigration).Assembly.FullName);
             });

            return new CouponDbContext(optionsBuilder.Options);
        }
    }
}
