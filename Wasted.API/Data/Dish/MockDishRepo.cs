using Wasted.API.Models;
using System.Collections.Generic;

namespace Wasted.API.Data
{
    public class MockDishRepo : IDishRepo
    {
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
<<<<<<< HEAD
        public IEnumerable<Dish> GetDishList()
        {
            List<Dish> Dishes = new List<Dish>
            {
                new Dish { Id = 1, Name =  "Chocolate Cake", numberOfIngredients = 4, Ingredients = "unknown", Type =  "Baked"},
                new Dish { Id = 2, Name = "Brownies", numberOfIngredients = 5, Ingredients = "unknown", Type = "Baked"}
=======
        public IEnumerable<Item> GetDishList()
        {
            List<Dish> Dishes = new List<Dish>
            {
>>>>>>> parent of cc1a163 (Revert "Dish API")
            };
            return Dishes;
        }

<<<<<<< HEAD
        public Dish GetDishById(int id)
        {
            return new Dish { Id = 2, Name = "Brownies", numberOfIngredients = 5, Ingredients = "unknown", Type = "Baked"};
        }


        public void CreateNewDish(Dish dish)
=======
        public Item GetItemById(int id)
        {
            return new Item { Id = 2, Name = "Cocoa", Amount = 75, MeasurementUnits = "g", Date = "2022-06-08"};
        }


        public void CreateNewItem(Item item)
>>>>>>> parent of cc1a163 (Revert "Dish API")
        {
            throw new System.NotImplementedException();
        }

<<<<<<< HEAD
        public void UpdateDish(Dish dish)
=======
        public void UpdateItem(Item item)
>>>>>>> parent of cc1a163 (Revert "Dish API")
        {
            throw new System.NotImplementedException();
        }

<<<<<<< HEAD
        public void DeleteDish(Dish dish)
=======
        public void DeleteItem(Item item)
>>>>>>> parent of cc1a163 (Revert "Dish API")
        {
            throw new System.NotImplementedException();
        }
    }
}
