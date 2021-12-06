using Microsoft.EntityFrameworkCore;
using Wasted.API.Models;

namespace Wasted.API.Data
{
    public class WastedContext : DbContext
    {
        public WastedContext(DbContextOptions<WastedContext> opt) : base(opt)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tip> Tips { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Apple", Type = "Fruit", MeasurementUnits = "kg", EnergyValue = 158.487},
                new Product { Id = 2, Name = "Troat", Type = "Fish", MeasurementUnits = "kg", EnergyValue = 284.546},
                new Product { Id = 3, Name = "Orange", Type = "Fruit", MeasurementUnits = "g", EnergyValue = 120.692},
                new Product { Id = 4, Name = "Blackberry", Type = "Berry", MeasurementUnits = "kg", EnergyValue = 262.178},
                new Product { Id = 5, Name = "Cheese", Type = "Dairy", MeasurementUnits = "kg", EnergyValue = 352.698},
                new Product { Id = 6, Name = "Bass", Type = "Fish", MeasurementUnits = "kg", EnergyValue = 271.745},
                new Product { Id = 7, Name = "Buttermilk", Type = "Dairy", MeasurementUnits = "l", EnergyValue = 175.1245}
                );

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name =  "TEST1", numberOfIngredients = 2, Type =  "Baked"},
                new Dish { Id = 2, Name = "TEST2", numberOfIngredients = 2, Type = "Baked"}
              );

            modelBuilder.Entity<Ingredient>().HasKey(c => new { c.DishId, c.ProductId });

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { DishId = 1, ProductId =  1, Amount =  1 },
                new Ingredient { DishId = 1, ProductId =  3, Amount =  2 },
                new Ingredient { DishId = 2, ProductId =  4, Amount =  3},
                new Ingredient { DishId = 2, ProductId =  5, Amount =  3}
              );



            modelBuilder.Entity<Tip>().HasData(
                new Tip { TipId = 1, TipName = "Shop Smart", 
                        Name = "To avoid buying more food than you need, make frequent trips to the grocery store every few days rather than doing a bulk shopping trip once a week.", 
                        TipLikes = 4, TipDislikes = 0, Link = "https://en.wikipedia.org/wiki/Smart_shop", AdminApproved = true},
                new Tip { TipId = 2, TipName = "Store Food Correctly", 
                        Name = "Separating foods that produce more ethylene gas from those that don’t is another great way to reduce food spoilage. Ethylene promotes ripening in foods and could lead to spoilage.", 
                        TipLikes = 4, TipDislikes = 0, Link = "https://www.betterhealth.vic.gov.au/health/healthyliving/food-safety-and-storage", AdminApproved = true},
                new Tip { TipId = 3, TipName = "Learn to Preserve", 
                        Name = "Pickling, drying, canning, fermenting, freezing and curing are all methods you can use to make food last longer, thus reducing waste.", 
                        TipLikes = 1, TipDislikes = 0, Link = "https://www.masterclass.com/articles/a-guide-to-home-food-preservation-how-to-pickle-can-ferment-dry-and-preserve-at-home", AdminApproved = true}
                );
           modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "julius.nar@gmail.com", FirstName = "Julius", LastName = "Narkunas", Password = "JuliusNer1", Role = "user" },
                new User { Id = 2, Email = "danielius.rekus@gmail.com", FirstName = "Danielius", LastName = "Rekus", Password = "Danius123", Role = "admin" },
                new User { Id = 3, Email = "mariuks@gmail.com", FirstName = "Marius", LastName = "Ivanausas", Password = "Jhbj433h", Role = "user"},
                new User { Id = 4, Email = "karolis@gmail.com", FirstName = "Karolis", LastName = "Valkauskas", Password = "Karolis123", Role = "admin"},
                new User { Id = 5, Email = "kajus@outlook.com", FirstName = "Kajus", LastName = "Orsauskas", Password = "Kaj47474p", Role = "user"}
              );
        }
    }
}
