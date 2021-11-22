using Wasted.API.Models;
using System.Collections.Generic;

namespace Wasted.API.Data
{
    public interface IDishRepo
    {
        bool SaveChanges();
        IEnumerable<Dish> GetDishList();
        Dish GetDishById(int id);
        void CreateNewDish(Dish dish);
        void UpdateDish(Dish dish);
        void DeleteDish(Dish dish);
    }
}
