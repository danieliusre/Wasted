using System;
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
            var filepath =  "RecipeList.json";
            try 
            {
                Log.Information("Started reading RecipeList");
                products = JsonConvert.DeserializeObject<List<RecipeModel>>(_jsonFileService.ReadJsonFromFile(filepath));
                Log.Information("Finished reading RecipeList");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return products;
        }
    }
}
