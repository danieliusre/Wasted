using Wasted.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Wasted.API.Data
{
    public class SqlIngredientRepo : IIngredientRepo
    {
        private readonly WastedContext _context;

        public SqlIngredientRepo(WastedContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<Ingredient> GetIngredientList()
        {
            return _context.Ingredients.ToList();
        }

        public IEnumerable<Ingredient> GetIngredientListByDishId(int DishId)
        {
            return _context.Ingredients.Where(p => p.DishId == DishId).ToList();
        }

        public void CreateNewIngredient(IEnumerable<Ingredient> ingredient)
        {
            if (ingredient == null){
                throw new ArgumentException(nameof(ingredient));
            }

            _context.Ingredients.AddRange(ingredient);
        }

        public void UpdateIngredient(IEnumerable<Ingredient> ingredient)
        {
            //Nothing
        }

        public void DeleteIngredient(IEnumerable<Ingredient> ingredient)
        {
            if (ingredient == null){
                throw new ArgumentException(nameof(ingredient));
            }

            _context.Ingredients.RemoveRange(ingredient);
        }
    }
}
