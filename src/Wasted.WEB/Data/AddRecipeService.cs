using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Wasted.Data
{
    public class AddRecipeService
    {
        private readonly HttpHelper _httpHelper;
        public string MsgToUser;

        public AddRecipeService(JsonFileService jsonFileService, HttpHelper httpHelper)
        {
             _httpHelper = httpHelper;
        }

        public async Task<Product> GetProductById(int productId)
        {
            Product product =  await _httpHelper.GetById<Product>(productId, "product");
            return product;
        }
        public async Task<List<RecipeItemModel>> AddIngredient(List<RecipeItemModel> ingredients, int productId, string amount)
        {
            await Task.Delay(1);
            Product product = await GetProductById(productId);
            RecipeItemModel newIngredient = new RecipeItemModel(){Item = product.Name, Amount = Int32.Parse(amount), Unit = product.MeasurementUnits};
            ingredients.Add(newIngredient);
            return ingredients;
        }

        public async Task<DishModel> CreateRecipe(List<RecipeItemModel> ingredients, string dishName, string dishType, int numberOfIngredients)
        {
            await Task.Delay(1);
            DishModel recipe = new DishModel();
            recipe.Name = dishName;
            recipe.numberOfIngredients = numberOfIngredients;
            recipe.Ingredients = ingredients;
            recipe.Type = dishType;
            return recipe;
        }
    }
}