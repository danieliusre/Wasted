using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Serilog;

namespace Wasted.Data
{
    public class RecipeCalcService
    {
        private JsonFileService _jsonFileService;

        public RecipeCalcService(JsonFileService jsonFileService)
        {
            _jsonFileService = jsonFileService;
        }
        public List<ItemModel> GetProducts()
        {
            var products =  new List<ItemModel>();
            var filepath =  "RecipeProductList.json";
            try 
            {
                Log.Information("Started reading RecipeProductList");
                products = JsonConvert.DeserializeObject<List<ItemModel>>(_jsonFileService.ReadJsonFromFile(filepath));
                Log.Information("Finished reading RecipeProductList");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return products;
        }
        public Task<List<ItemModel>> SaveProducts(List<ItemModel> products)
        {
            var filePath = "RecipeProductList.json";
            foreach(var product in products)
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
            } 
            try 
            {
                Log.Information("Starting writing RecipeProductList");
                _jsonFileService.WriteJsonToFile(JsonConvert.SerializeObject(products, Formatting.Indented),filePath);
                Log.Information("Finished writing RecipeProductlist");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return Task.FromResult(products);
        }

        public List<String> FindExpiringProducts(List<ItemModel> products)
        {
            List<String> badProducts = new();
            try 
            {
                foreach (var product in products)
                {
                    product.Item = char.ToUpper(product.Item[0]) + product.Item.Substring(1);
                    if((DateTime.Parse(product.Date) - DateTime.Today).TotalDays < 3)
                    {
                        badProducts.Add(product.Item);
                    }
                } 
                Log.Information("Found all expired products");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return badProducts;
        }

        public List<DishModel> FindRecipe(List<ItemModel> products)
        {
            List<DishModel> dishes = new List<DishModel>();
            try 
            {
                Log.Information("Starting to search for Recipes");
                var filePath = "Recipes.txt";
                System.IO.StreamReader RecipeFile = new System.IO.StreamReader(filePath);
                List<ItemModel> ingredients = new List<ItemModel>();
                do
                {
                    string dishName = RecipeFile.ReadLine();
                    int Need = Int32.Parse(RecipeFile.ReadLine());
                    ingredients.Clear();            
                    for (int i = 0; i<Need; i++)
                    {
                        string[] item = RecipeFile.ReadLine().Split(';');
                        ingredients.Add(new ItemModel(){Item = item[0], Amount = Int32.Parse(item[1]), Unit = item[2]});
                    }
                    foreach (var ingredient in ingredients)
                    {
                        foreach(var product in products)
                        {
                            if(ingredient.Item.Equals(product.Item.ToLower()) && ingredient.Amount <= product.Amount)
                            {
                                Need--;
                            }
                        }   
                    }
                    if(Need == 0)
                    {
                        dishes.Add(new DishModel(){Name = dishName, Ingredients = new List<ItemModel>(ingredients), Relevance = ingredients.Count()});
                    }
                }while(RecipeFile.ReadLine() != null);

                Log.Information("Finished finding all recipes");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            dishes.Sort();
            return dishes;
        }
    }
}
