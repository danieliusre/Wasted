using Wasted.API.Models;
using System.Collections.Generic;

namespace Wasted.API.Data
{
    public interface IIngredientRepo
    {
        bool SaveChanges();
        IEnumerable<Ingredient> GetIngredientList();
        IEnumerable<Ingredient> GetIngredientListByDishId(int DishId);
        void CreateNewIngredient(IEnumerable<Ingredient> Ingredient);
        void UpdateIngredient(IEnumerable<Ingredient> Ingredient);
        void DeleteIngredients(IEnumerable<Ingredient> Ingredients);
    }
}
