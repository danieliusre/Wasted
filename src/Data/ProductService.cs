using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
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

        public async Task<ProductList> GetProducts()
        {
            ProductList products = null;
            try 
            {
                var filePath = "ProductList.json";
                Log.Information("Starting to read ProductList");
                await Task.Delay(5000); // Just for async to really show of :)
                products =  new ProductList(
                    JsonConvert.DeserializeObject<Product[]>(
                        _jsonFileService.ReadJsonFromFile(filePath)
                    ));
                Log.Information("Finished reading Productlist");
                
            }
            catch(FileNotFoundException e)
            {
                Log.Error(e.Message);
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return products;
        }
        /* 
        public Task<ProductList> SaveProducts(ProductList products)
        {
            var filePath = "ProductList.json";
            try 
            {
                Log.Information("Starting to read ProductList");
                _jsonFileService.WriteJsonToFile(JsonConvert.SerializeObject(products, Formatting.Indented),filePath);
                Log.Information("Finished reading Productlist");
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return Task.FromResult(products);
        }*/
    }
}
