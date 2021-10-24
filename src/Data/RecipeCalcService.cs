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
        public List<ProductModel> GetProducts()
        {
            var products =  new List<ProductModel>();
            var filepath =  "RecipeProductList.json";
            try 
            {
                Log.Information("Started reading RecipeProductList");
                products = JsonConvert.DeserializeObject<List<ProductModel>>(_jsonFileService.ReadJsonFromFile(filepath));
                Log.Information("Finished reading RecipeProductList");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return products;
        }
        public Task<List<ProductModel>> SaveProducts(List<ProductModel> products)
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

        public List<String> FindExpiringProducts(List<ProductModel> products)
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

        public List<DishModel> FindRecipe(List<ProductModel> products)
        {
            List<DishModel> dishes = new List<DishModel>();
            try 
            {
                Log.Information("Starting to search for Recipes");
                var filePath = "Recipes.txt";
                System.IO.StreamReader RecipeFile = new System.IO.StreamReader(filePath);
                List<ProductModel> ingredients = new List<ProductModel>();
                do
                {
                    string dishName = RecipeFile.ReadLine();
                    int Need = Int32.Parse(RecipeFile.ReadLine());
                    string dishType = RecipeFile.ReadLine();
                    ingredients.Clear();            
                    for (int i = 0; i<Need; i++)
                    {
                        string[] item = RecipeFile.ReadLine().Split(';');
                        ingredients.Add(new ProductModel(){Item = item[0], Amount = Int32.Parse(item[1]), Unit = item[2]});
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
                        dishes.Add(new DishModel(){Name = dishName, Ingredients = new List<ProductModel>(ingredients), Relevance = ingredients.Count(), Type = dishType});
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
    public class DishType
    {
        public event EventHandler FilterButtonPressed;

        public static string ReturnDishType(string sender)
        {
            string dishType;
            switch (sender)
            {
                case "All":
                    dishType = "All";
                    break;
                case "Baked":
                    dishType = "Baked";
                    break;
                case "Pasta":
                    dishType = "Pasta";
                    break;
                case "Salad":
                    dishType = "Salad";
                    break;
                case "Soup":
                    dishType = "Soup";
                    break;
                default:
                    dishType = "All";
                    break;
            }
            return dishType;
        }
    }
}
