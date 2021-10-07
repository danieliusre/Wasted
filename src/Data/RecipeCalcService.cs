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
        public List<RecipeModel> GetProducts()
        {
            var products =  new List<RecipeModel>();
            var filepath =  "RecipeProductList.json";
            try 
            {
                Log.Information("Started reading RecipeProductList");
                products = JsonConvert.DeserializeObject<List<RecipeModel>>(_jsonFileService.ReadJsonFromFile(filepath));
                Log.Information("Finished reading RecipeProductList");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return products;
        }
        public Task<List<RecipeModel>> SaveProducts(List<RecipeModel> products)
        {
            var filePath = "RecipeProductList.json";
            foreach(var product in products)
            {
                if(product.Unit == "kg")
                {product.Left = product.Left * 1000; product.Unit = "g";}
                else if(product.Unit == "l")
                {product.Left = product.Left * 1000; product.Unit = "ml";}
                else if(product.Unit == "oz")
                {product.Left = product.Left * 28; product.Unit = "g";}
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

        public List<String> FindExpiredProducts(List<RecipeModel> products)
        {
            List<String> badProducts = new();
            try 
            {
                Log.Information("Started reading RecipeProductList");
                foreach (var product in products)
                {
                    product.Item = char.ToUpper(product.Item[0]) + product.Item.Substring(1);
                    if((DateTime.Parse(product.Date) - DateTime.Today).TotalDays < 3)
                    {
                        badProducts.Add(product.Item);
                    }
                } 
                Log.Information("Finished reading RecipeProductList");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return badProducts;
        }

        public List<DishModel> FindRecipe(List<RecipeModel> products)
        {
            List<DishModel> dishes = new List<DishModel>();
            try 
            {
                Log.Information("Starting to search for Recipes");
                var filePath = "Recipes.txt";
                System.IO.StreamReader RecipeFile = new System.IO.StreamReader(filePath);
                List<RecipeModel> ingredients = new List<RecipeModel>();
                do
                {
                    string dishName = RecipeFile.ReadLine();
                    int Need = Int32.Parse(RecipeFile.ReadLine());
                    ingredients.Clear();            
                    for (int i = 0; i<Need; i++)
                    {
                        string[] item = RecipeFile.ReadLine().Split(';');
                        ingredients.Add(new RecipeModel(){Item = item[0], Left = Int32.Parse(item[1]), Unit = item[2]});
                    }
                    foreach (var ingredient in ingredients)
                    {
                        foreach(var product in products)
                        {
                            if(ingredient.Item.Equals(product.Item.ToLower()) && ingredient.Left <= product.Left)
                            {
                                Need--;
                            }
                        }   
                    }
                    if(Need == 0)
                    {
                        dishes.Add(new DishModel(){Name = dishName, Ingredients = new List<RecipeModel>(ingredients)});
                    }
                }while(RecipeFile.ReadLine() != null);

                Log.Information("Finished finding all recipes");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return dishes;
        }
    }
}
