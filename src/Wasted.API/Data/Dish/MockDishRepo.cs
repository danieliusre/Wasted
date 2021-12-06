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
        public IEnumerable<Dish> GetDishList()
        {
            List<Dish> Dishes = new List<Dish>
            {
                new Dish { Id = 1, Name =  "Chocolate Cake", numberOfIngredients = 4, /* Ingredients = "unknown",*/ Type =  "Baked"},
                new Dish { Id = 2, Name = "Brownies", numberOfIngredients = 5, /*Ingredients = "unknown",*/ Type = "Baked"}
            };
            return Dishes;
        }


        public Dish GetDishById(int id)
        {
            return new Dish { Id = 2, Name = "Brownies", numberOfIngredients = 5,/* Ingredients = "unknown",*/ Type = "Baked"};
        }

        void IDishRepo.CreateNewDish(Dish dish)
        {
            throw new System.NotImplementedException();
        }

        void IDishRepo.UpdateDish(Dish dish)
        {
            throw new System.NotImplementedException();
        }

        void IDishRepo.DeleteDish(Dish dish)
        {
            throw new System.NotImplementedException();
        }
    }
}
