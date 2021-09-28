using Ordering.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
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
