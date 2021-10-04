using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Serilog;

namespace Wasted.Data
{
    public class ProductService
    {
        private readonly JsonFileService _jsonFileService;

        public ProductService(JsonFileService jsonFileService)
        {
            _jsonFileService = jsonFileService;
        }

        public Task<List<Product>> GetProducts()
        {
            var products =  new List<Product>();
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "ProductList.txt";
            try 
            {
                Log.Information("Starting to ProductList");
                products = JsonConvert.DeserializeObject<List<Product>>(_jsonFileService.ReadJsonFromFile(filePath));
                Log.Information("Finished reading Productlist");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return Task.FromResult(products);
        }
    }
}
