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
                new City { Id = 1, Name = "Москва", NameNormalized = "МОСКВА" },
                new City { Id = 2, Name = "Московский", NameNormalized = "МОСКОВСКИЙ" },
                new City { Id = 3, Name = "Москворечье", NameNormalized = "МОСКВОРЕЧЬЕ" },

                new City { Id = 4, Name = "Санкт-Петербург", NameNormalized = "САНКТ-ПЕТЕРБУРГ" },
                new City { Id = 5, Name = "Петергоф", NameNormalized = "ПЕТЕРГОФ" },

                new City { Id = 6, Name = "Новосибирск", NameNormalized = "НОВОСИБИРСК" },
                new City { Id = 7, Name = "Сибирский", NameNormalized = "СИБИРСКИЙ" },

                new City { Id = 8, Name = "Казань", NameNormalized = "КАЗАНЬ" },
                new City { Id = 9, Name = "Казанка", NameNormalized = "КАЗАНКА" },

                new City { Id = 10, Name = "Ростов-на-Дону", NameNormalized = "РОСТОВ-НА-ДОНУ" },
                new City { Id = 11, Name = "Ростов Великий", NameNormalized = "РОСТОВ ВЕЛИКИЙ" },

                new City { Id = 12, Name = "Краснодар", NameNormalized = "КРАСНОДАР" },
                new City { Id = 13, Name = "Красноярск", NameNormalized = "КРАСНОЯРСК" },

                new City { Id = 14, Name = "Владивосток", NameNormalized = "ВЛАДИВОСТОК" },
                new City { Id = 15, Name = "Владимир", NameNormalized = "ВЛАДИМИР" },

                new City { Id = 16, Name = "Волгоград", NameNormalized = "ВОЛГОГРАД" },
                new City { Id = 17, Name = "Вологда", NameNormalized = "ВОЛОГДА" },
                new City { Id = 18, Name = "Воронеж", NameNormalized = "ВОРОНЕЖ" },

                new City { Id = 19, Name = "Екатеринбург", NameNormalized = "ЕКАТЕРИНБУРГ" },
                new City { Id = 20, Name = "Екатериновка", NameNormalized = "ЕКАТЕРИНОВКА" }
            );

            modelBuilder.Entity<Order>(entity => {
                entity.HasIndex(o => o.OrderNumber).IsUnique();
                entity.HasOne(o => o.SenderCity).WithMany().OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(o => o.ReceiverCity).WithMany().OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
