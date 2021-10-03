using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.Entities;

namespace Product.Infrastructure.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


        public DbSet<Plant> Plants { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category[]
                {
                    new Category
                    {
                    Id = 1,
                    Name = "Сад",
                    Description = "Великолепные растения для вашего заднего участка"
                    },
                    new Category
                    {
                    Id = 2,
                    Name = "Огород",
                    Description = "Лучший выбор для вашего огорода"
                    }
                });

            modelBuilder.Entity<Plant>().HasData(
                new Plant
                {
                    Id = 1,
                    Name = "Клубника",
                    ShortDescription = "Красная ягода",
                    LongDescription = "Самая вкусная ягодка",
                    IsFavourite = false,
                    IsAvailable = true,
                    Price = 5,
                    CategoryId = 1,
                },
                new Plant
                {
                    Id = 2,
                    Name = "Земляника",
                    ShortDescription = "Меьше клубники,но не менее вкусная",
                    LongDescription = "",
                    IsFavourite = false,
                    IsAvailable = true,
                    Price = 10,
                    CategoryId = 1,
                },
                new Plant
                {
                    Id = 3,
                    Name = "Черника",
                    ShortDescription = "Прямо из леса",
                    LongDescription = "Самая вкусная ягодка",
                    IsFavourite = false,
                    IsAvailable = true,
                    Price = 20,
                    CategoryId = 1,
                },
                new Plant
                {
                    Id = 4,
                    Name = "Магнолия",
                    ShortDescription = "Самый яркий",
                    LongDescription = "Почувствуй настроение лета",
                    IsFavourite = true,
                    IsAvailable = true,
                    Price = 300,
                    CategoryId = 2,
                },
                new Plant
                {
                    Id = 5,
                    Name = "Лаванда",
                    ShortDescription = "Аромат прованса",
                    LongDescription = "Почувствуй настроение лета",
                    IsFavourite = true,
                    IsAvailable = true,
                    Price = 150,
                    CategoryId = 2,
                },
                new Plant
                {
                    Id = 6,
                    Name = "Гортензия",
                    ShortDescription = "Великолепный цветок",
                    LongDescription = "Почувствуй настроение лета",
                    IsFavourite = true,
                    IsAvailable = true,
                    Price = 200,
                    CategoryId = 2,
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
