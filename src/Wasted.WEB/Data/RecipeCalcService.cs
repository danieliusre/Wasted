using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Serilog;

namespace Wasted.Data
{
    public class RecipeCalcService
    {
        private readonly HttpHelper _httpHelper;
        public string MsgToUser;
        public string ExpiredListTooLong = "More than 2 of your products have expired, consider removing them from your list!";

        public RecipeCalcService(HttpHelper httpHelper)
        {
             _httpHelper = httpHelper;
        }

        public async Task<List<RecipeItemModel>> GetFridgeItems(int userId)
        {
            List<FridgeItem> fridgeItems = new List<FridgeItem>();
            List<RecipeItemModel> products = new List<RecipeItemModel>();
            try 
            {
                Log.Information("Starting to read FridgeItems");
                fridgeItems =  new List<FridgeItem>(await _httpHelper.GetList<FridgeItem>("fridge/"+ userId.ToString()));
                Log.Information("Finished reading FridgeItems");
                foreach (var fridgeItem in fridgeItems)
                {
                    RecipeItemModel newProduct = new RecipeItemModel();
                    newProduct.Item = fridgeItem.Name;
                    newProduct.Amount = Int32.Parse(fridgeItem.Amount);
                    newProduct.Unit = fridgeItem.MeasurementUnits;
                    newProduct.Date = fridgeItem.Date;
                    newProduct = await ChangeMeasurements(newProduct);
                    products.Add(newProduct);
                }
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return products;
        }
        public async Task<DishModel> AddRecipe(DishModel recipe)
        {
            try 
            {
                Log.Information("Starting writing recipe");
                int newDishId = await _httpHelper.Post<DishModel>(recipe, "dish");
                await _httpHelper.Post<List<RecipeItemModel>>(recipe.Ingredients, "ingredient/" + newDishId.ToString());
                Log.Information("Finished writing recipe");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return recipe;
        }


        public List<String> FindExpiringProducts(List<RecipeItemModel> products)
        {
            List<String> badProducts = new();
            try 
            {
                badProducts = products.Where(product => (DateTime.Parse(product.Date) - DateTime.Today).TotalDays <= 4 && (DateTime.Parse(product.Date) - DateTime.Today).TotalDays >= 0)
                .Select(product => product.Item).ToList();
                Log.Information("Found all expiring products");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return badProducts;
        }

        public List<String> FindExpiredProducts(List<RecipeItemModel> products)
        {
            List<String> badProducts = new();
            try 
            {
                badProducts = products.Where(product => (DateTime.Parse(product.Date) - DateTime.Today).TotalDays < 0)
                .Select(product => product.Item).ToList();
                Log.Information("Found all expired products");
                Predicate<List<string>> tooLong = new Predicate<List<string>>(CheckLength);
                if(tooLong.Invoke(badProducts))
                {
                    MsgToUser = ExpiredListTooLong;
                }
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return badProducts;
        }

        public List<RecipeItemModel> RemoveExpiredProducts(List<RecipeItemModel> products)
        {
            List<String> badProducts = new();
            badProducts = FindExpiredProducts(products);
            products = products.Where(product => !badProducts.Contains(product.Item)).ToList();
            MsgToUser = "";
            return products;
        }

        public bool haveEnoughIngredients(List<RecipeItemModel> products, DishModel recipe)
        {
            int have = 0;
            foreach (var product in products)
            {
                for(int i = 0; i < recipe.numberOfIngredients; i++)
                {
                    if(string.Equals(product.Item, recipe.Ingredients[i].Item, StringComparison.OrdinalIgnoreCase) && product.Amount >= recipe.Ingredients[i].Amount)
                    {
                        have++;
                    }
                }
            }
            if(have == recipe.numberOfIngredients)
            {
                return true;
            }
            return false;
        }

        public async Task<List<DishModel>> FindRecipe(List<RecipeItemModel> products, CanMakeDish makeable)
        {
            List<DishModel> dishesAbleToMake = new List<DishModel>();
            try 
            {
                await Task.Delay(1);
                Log.Information("Starting to search for recipes");
                var recipes = await GetRecipes();
                dishesAbleToMake = recipes.Where(recipe => haveEnoughIngredients(products, recipe) == true).ToList();
                Log.Information("Finished finding all recipes");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            dishesAbleToMake.Sort();
            return dishesAbleToMake;
        }

        public async Task<List<DishModel>> GetRecipes()
        {
            List<DishModel> recipes = new List<DishModel>();
            try 
            {
                Log.Information("Starting to read api/dish");
                await Task.Delay(1);
                recipes =  new List<DishModel>(await _httpHelper.GetList<DishModel>("dish"));
                Log.Information("Finished reading api/dish");
            }
            catch(FileNotFoundException e)
            {
                Log.Error(e.Message);
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return recipes;
        }


        public Task<RecipeItemModel> ChangeMeasurements(RecipeItemModel product)
            {
                switch (product.Unit)
                {
                    case "kg":
                        product.Amount = product.Amount * 1000;
                        product.Unit = "g";
                        break;
                    case "l":
                        product.Amount = product.Amount * 1000;
                        product.Unit = "ml";
                        break;
                    case "oz":
                        product.Amount = product.Amount * 28;
                        product.Unit = "ml/g";
                        break;
                    default:
                        break;
                }
                return Task.FromResult(product);
            }

        public static bool CheckLength(List<string> badProducts)
        {
            if(badProducts.Count() > 2)
            {
                return true;
            }
            return false;
        }
    }
}
