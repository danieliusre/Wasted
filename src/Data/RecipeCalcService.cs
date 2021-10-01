// using System;
// using System.Threading.Tasks;
// using System.IO;
// using System.Collections.Generic;
// using Newtonsoft.Json;
// using Serilog;

// namespace Wasted.Data
// {
//     public class RecipeCalcService
//     {
//         private JsonFileService _jsonFileService;

//         public RecipeCalcService(JsonFileService jsonFileService)
//         {
//             _jsonFileService = jsonFileService;
//         }
//         public Task<List<RecipeCalcProduct>> GetProducts()
//         {
//             var products =  new List<RecipeCalcProduct>();
//             var filePath = AppDomain.CurrentDomain.BaseDirectory + "DB\\RecipeList.txt";
//             try 
//             {
//                 Log.Information("Started reading RecipeList");
//                 products = JsonConvert.DeserializeObject<List<RecipeCalcProduct>>(_jsonFileService.ReadJsonFromFile(filePath));
//                 Log.Information("Finished reading RecipeList");
//             }
//             catch (Exception e)
//             {
//                 Log.Error("Exception caught: {0}",e);
//             }
//             return Task.FromResult(products);
//         }
//     }
// }
