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
<<<<<<< HEAD
            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name =  "Chocolate Cake", numberOfIngredients = 4, Ingredients = "unknown", Type =  "Baked"},
                new Dish { Id = 2, Name = "Brownies", numberOfIngredients = 5, Ingredients = "unknown", Type = "Baked"}
=======

            modelBuilder.Entity<Tip>().HasData(
                new Tip { TipId = 1, TipName = "Shop Smart", 
                        Name = "To avoid buying more food than you need, make frequent trips to the grocery store every few days rather than doing a bulk shopping trip once a week.", 
                        TipLikes = 4, TipDislikes = 0, Link = "https://en.wikipedia.org/wiki/Smart_shop"},
                new Tip { TipId = 2, TipName = "Store Food Correctly", 
                        Name = "Separating foods that produce more ethylene gas from those that don’t is another great way to reduce food spoilage. Ethylene promotes ripening in foods and could lead to spoilage.", 
                        TipLikes = 4, TipDislikes = 0, Link = "https://www.betterhealth.vic.gov.au/health/healthyliving/food-safety-and-storage"},
                new Tip { TipId = 3, TipName = "Learn to Preserve", 
                        Name = "Pickling, drying, canning, fermenting, freezing and curing are all methods you can use to make food last longer, thus reducing waste.", 
                        TipLikes = 1, TipDislikes = 0, Link = "https://www.masterclass.com/articles/a-guide-to-home-food-preservation-how-to-pickle-can-ferment-dry-and-preserve-at-home"}
>>>>>>> main
                );
        }
    }
}
