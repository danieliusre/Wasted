using Wasted.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Wasted.API.Data
{
    public class SqlDishRepo : IDishRepo
    {
        private readonly WastedContext _context;

        public SqlDishRepo(WastedContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<Dish> GetDishList()
        {
            return _context.Dishes.ToList();
        }

        public Dish GetDishById(int id)
        {
            return _context.Dishes.FirstOrDefault(p => p.Id == id);
        }

        public void CreateNewDish(Dish dish)
        {
            if (dish == null){
                throw new ArgumentException(nameof(dish));
            }

            _context.Dishes.Add(dish);
        }

        public void UpdateDish(Dish dish)
        {
            //Nothing
        }

        public void DeleteDish(Dish dish)
        {
            if (dish == null){
                throw new ArgumentException(nameof(dish));
            }

            _context.Dishes.Remove(dish);
        }
    }
}
