using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProduktKatalog.Models;

namespace ProduktKatalog.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                base.OnModelCreating(modelBuilder);

                //Seed data
                modelBuilder.Entity<Product>().HasData(
                    
                    new Product { Id= 1, Name= "Pizza Margherita", Description= "Klassisk pizza med tomat och mozzarella.", Price= 85, Category= "Maträtt", ImageUrl= "/images/margherita.jpg" },
                    new Product { Id = 2, Name = "Kanelbulle", Description = "Svensk klassiker med kanel och kardemumma.", Price = 25, Category = "Bakverk", ImageUrl = "/images/kanelbulle.jpg" },
                   new Product { Id = 3, Name = "Chokladtårta", Description = "Saftig chokladkaka med glasyr.", Price = 40, Category = "Bakverk", ImageUrl = "/images/chokladtårta.jpg" },
                    new Product { Id = 4, Name = "Grill Mix", Description = "Grillad kyckling, lamm och köttfärsspett", Price = 140, Category = "Maträtt", ImageUrl = "/images/grillmix.jpg" },
                    new Product { Id = 5, Name = "Pad thai", Description = "Pad thai med kyckling eller räkor", Price = 140, Category = "Maträtt", ImageUrl = "/images/padthai.jpg" },
                     new Product { Id = 6, Name = "Cheescake", Description = "Färsk och saftig cheescake", Price = 50, Category = "Bakverk", ImageUrl = "/images/cheescake.jpg" }
                    );


            }
        }
    }
}
