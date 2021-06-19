using mango.shopping.cart.repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace mango.shopping.cart.repository.DbContexts
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> dbContextOptions) : base(dbContextOptions)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartHeader>()
                .HasMany(x => x.CartDetail)
                .WithOne(x => x.CartHeader)
                .HasForeignKey(x => x.CartHeaderId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CartDetail>().HasOne(x => x.Product).WithOne().HasForeignKey("ProductId");
            
        }

    }
}
