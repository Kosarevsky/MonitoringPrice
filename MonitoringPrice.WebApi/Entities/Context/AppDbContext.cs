using Microsoft.EntityFrameworkCore;
using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Entities.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<Characteristic> Characteristic { get; set; } = null!;
        public DbSet<Manufacturer> Manufacturer { get; set; } = null!;
        public DbSet<Price> Price { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
        public DbSet<Ram> Ram { get; set; } = null!;
        public DbSet<Url> Url { get; set; } = null!;
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category
            { Id = 1, CategoryName = "Смартфоны" });
            modelBuilder.Entity<Category>().HasData(new Category
            { Id = 2, CategoryName = "Планшеты" });

            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer
            { Id = 1, ManufacturerName = "Xiaomi" });

            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer
            { Id = 2, ManufacturerName = "POCO" });

            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer
            { Id = 3, ManufacturerName = "RealMe" });

            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer
            { Id = 4, ManufacturerName = "UMIDIGI" });

            modelBuilder.Entity<WebSite>().HasData(new WebSite
            { Id = 1, Name = "Aliexpress" });

            modelBuilder.Entity<WebSite>().HasData(new WebSite
            { Id = 2, Name = "Banggood" });

            modelBuilder.Entity<Product>().HasData(new Product
            { Id = 1, ManufacturerId = 1, CategoryId = 1, ProductName = "Redmi 10" });

            modelBuilder.Entity<Product>().HasData(new Product
            { Id = 2, ManufacturerId = 4, CategoryId = 1, ProductName = "A11" });

            modelBuilder.Entity<Ram>().HasData(new Ram
            { Id = 1, ProductId = 1, RamName = "4/64 ГБ" });

            modelBuilder.Entity<Url>().HasData(new Url
            { Id = 1, RamId = 1, Link = "https://aliexpress.ru/item/1005003212627329.html" });

            modelBuilder.Entity<Characteristic>().HasData(new Characteristic
            { Id = 1, UrlId = 1, CharacteristicName = "Gray" });
        }
    }
}
