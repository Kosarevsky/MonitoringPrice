using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MonitoringPrice.Data.Entities.Models
{
    public sealed class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Characteristic> Characteristic { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Ram> Ram { get; set; }
        public DbSet<Url> Url { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {  Id = 1, CategoryName = "Смартфоны"  });
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
            { Id =1 , Name = "Aliexpress"});
            
            modelBuilder.Entity<WebSite>().HasData(new WebSite
            { Id = 2, Name = "Banggood" });

            modelBuilder.Entity<Product>().HasData(new Product
            { Id = 1, ManufacturerId = 1,  CategoryId = 1, ProductName = "Redmi 10" });

            modelBuilder.Entity<Product>().HasData(new Product
            { Id = 2, ManufacturerId =4,  CategoryId = 1, ProductName = "A11" });

            modelBuilder.Entity<Ram>().HasData(new Ram
            { Id = 1,  ProductId=1,  RamName = "4/64 ГБ"});

            modelBuilder.Entity<Url>().HasData(new Url
            { Id = 1, RamId = 1, Link = "https://aliexpress.ru/item/1005003212627329.html" });

            modelBuilder.Entity<Characteristic>().HasData(new Characteristic
            { Id = 1, UrlId = 1, CharacteristicName = "Gray" });
        }
    }
}
