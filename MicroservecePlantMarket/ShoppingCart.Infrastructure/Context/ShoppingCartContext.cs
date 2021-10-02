using Microsoft.EntityFrameworkCore;
using ShoppingCart.Infrastructure.Entities;

namespace ShoppingCart.Infrastructure.Context
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //
            base.OnModelCreating(modelBuilder);
        }
    }
}
