using Microsoft.EntityFrameworkCore;

namespace mango.coupon.repository.DbContexts
{
    public class CouponDbContext : DbContext
    {
        public CouponDbContext(DbContextOptions<CouponDbContext> dbContextOptions) : base(dbContextOptions)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
