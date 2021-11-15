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
        }
    }
}
