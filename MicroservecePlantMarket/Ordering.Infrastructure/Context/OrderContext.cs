using Microsoft.EntityFrameworkCore;
using Ordering.Infrastructure.Entities;

namespace Ordering.Infrastructure.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderedPlant> OrderedPlants { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            base.OnModelCreating(modelBuilder);
        }
    }
}
