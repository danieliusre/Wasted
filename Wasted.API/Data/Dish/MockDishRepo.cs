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
        public IEnumerable<Item> GetDishList()
        {
            List<Dish> Dishes = new List<Dish>
            {
            };
            return Dishes;
        }

        public Item GetItemById(int id)
        {
            return new Item { Id = 2, Name = "Cocoa", Amount = 75, MeasurementUnits = "g", Date = "2022-06-08"};
        }


        public void CreateNewItem(Item item)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteItem(Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}
