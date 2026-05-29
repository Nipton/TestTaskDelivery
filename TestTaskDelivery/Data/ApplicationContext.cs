using Microsoft.EntityFrameworkCore;
using TestTaskDelivery.Models;

namespace TestTaskDelivery.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
               new City { Id = 1, Name = "Москва" },
               new City { Id = 2, Name = "Санкт-Петербург" },
               new City { Id = 3, Name = "Новосибирск" },
               new City { Id = 4, Name = "Екатеринбург" },
               new City { Id = 5, Name = "Казань" },
               new City { Id = 6, Name = "Нижний Новгород" },
               new City { Id = 7, Name = "Челябинск" },
               new City { Id = 8, Name = "Омск" },
               new City { Id = 9, Name = "Ростов-на-Дону" },
               new City { Id = 10, Name = "Уфа" }
            );

            modelBuilder.Entity<Order>().HasOne(o => o.SenderCity).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>().HasOne(o => o.ReceiverCity).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
