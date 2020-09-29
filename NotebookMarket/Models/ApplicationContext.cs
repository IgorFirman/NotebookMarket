using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotebookMarket.Models
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Для навчання" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Ультратонкі" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Геймерські" });

            // seed laptops
            modelBuilder.Entity<Laptop>().HasData(new Laptop
            {
                LaptopId = 1,
                Model = "НОУТБУК LENOVO IdeaPad L340-15IRH Gaming",
                Price = 21000,
                ShortDescription = "IdeaPad L340 Gaming - ігровий ноутбук,який поєднує в собі портативність і продуктивність для забезпечення кращого досвіду геймінгу у будь - якому місці. ",
                LongDescription = "Серія (модельний ряд): L340 Gaming; Тип ноутбуку: Ігровий; Діагональ дисплея: 15.6 FullHD(1920 х 1080) IPS; Процесор 9 - th generation Intel Core i5 9300H(1.6 - 4.1 ГГц); Кількість ядер: 4; Оперативна пам'ять: 8 ГБ; Об'єм SSD: 512 ГБ; No ODD; Відеокарта: NVIDIA GeForce GTX1050; Об'єм вбудованої відеопам'яті: 3 ГБ; Бездротові технології: Bluetooth, Wi - Fi; Інтерфейси та підключення: 1 х USB 2.0, USB 3.2 Type - C, 1 х USB 3.2, HDMI, Комбінований аудіороз'єм; Програмне забезпечення: Windows 10 Home; Особливості: підсвітка клавіатури; Фізичні характеристики: Ширина - 302 мм, Висота - 18 мм, Глибина - 189 мм, Вага - 2.2 кг, Колір - синій.",
                ImageUrl = "https://brain.com.ua/static/images/prod_img/3/7/U0371137_big.jpg",
                OnDiscount = true,
                Available = true,
                CategoryId = 3,
            });
            modelBuilder.Entity<Laptop>().HasData(new Laptop
            {
                LaptopId = 2,
                Model = "НОУТБУК LENOVO THINKPAD X13 YOGA",
                Price = 60300,
                ShortDescription = "Надійність, потужність, мультирежимність притаманні Lenovo ThinkPad X13 YOGA ",
                LongDescription = "Серія (модельний ряд): ThinkPad; Тип ноутбуку: Ультратонкий; Діагональ дисплея: 13.3 FullHD(1920 х 1080) IPS; Процесор 10 - th generation Intel Core i5 10210U(1.6 - 4.2 ГГц); Кількість ядер: 4; Оперативна пам'ять: 16 ГБ; Об'єм SSD: 512 ГБ; No ODD; Відеокарта: Intel UHD Graphics 620; Об'єм вбудованої відеопам'яті: 2 ГБ; Бездротові технології: Bluetooth, Wi - Fi; Інтерфейси та підключення: 1 х USB 2.0, USB 3.2 Type - C, 1 х USB 3.2, HDMI, Комбінований аудіороз'єм; Програмне забезпечення: Windows 10 Home; Особливості: підсвітка клавіатури;Фізичні характеристики: Ширина - 302 мм, Висота - 18 мм, Глибина - 189 мм, Вага - 1.25 кг, Колір - чорний.",
                ImageUrl = "https://brain.com.ua/static/images/prod_img/7/2/U0465272_big.jpg",
                OnDiscount = true,
                Available = true,
                CategoryId = 2,
            });
            modelBuilder.Entity<Laptop>().HasData(new Laptop
            {
                LaptopId = 3,
                Model = "НОУТБУК ASUS ZENBOOK UX334FLC-A3108T",
                Price = 30999,
                ShortDescription = "Asus ZenBook UX334FLC – неперевершена краса, яка закута у корпус з фантастичною обробкою.",
                LongDescription = "Серія (модельний ряд): ASUS Zenbook; Тип ноутбуку: Бізнеc; Діагональ дисплея: 13.3 FullHD(1920 х 1080) IPS; Процесор 10 - th generation Intel Core i5 10210U(1.6 - 4.2 ГГц); Кількість ядер: 4; Оперативна пам'ять: 8 ГБ; Об'єм SSD: 512 ГБ; No ODD; Відеокарта: NVIDIA GeForce MX250; Об'єм вбудованої відеопам'яті: 2 ГБ; Бездротові технології: Bluetooth, Wi - Fi; Інтерфейси та підключення: 1 х USB 2.0, USB 3.2 Type - C, 1 х USB 3.2, HDMI, Комбінований аудіороз'єм; Програмне забезпечення: Windows 10 Home; Особливості: підсвітка клавіатури;Фізичні характеристики: Ширина - 302 мм, Висота - 18 мм, Глибина - 189 мм, Вага - 1.19 кг, Колір - синій.",
                ImageUrl = "https://brain.com.ua/static/images/prod_img/4/4/U0443644_big.jpg",
                OnDiscount = true,
                Available = true,
                CategoryId = 1,
            });


        }


    }
}
