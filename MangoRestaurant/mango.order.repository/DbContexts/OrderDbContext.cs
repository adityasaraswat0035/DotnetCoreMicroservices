using mango.coupon.repository.Entities;
using mango.order.repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace mango.order.repository.DbContexts
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> dbContextOptions) : base(dbContextOptions)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
                .HasOne(x => x.OrderHeader)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderHeaderId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
