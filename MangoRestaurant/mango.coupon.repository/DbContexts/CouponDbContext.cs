using mango.coupon.repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace mango.coupon.repository.DbContexts
{
    public class CouponDbContext : DbContext
    {
        public CouponDbContext(DbContextOptions<CouponDbContext> dbContextOptions) : base(dbContextOptions)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        DbSet<Coupon> Coupons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
