using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Serilog;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Wasted.Data
{
    public class ProductService
    {
        private static readonly HttpClient client = new HttpClient();
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
                Log.Information("Starting to read ProductList");
                await Task.Delay(5000); // Just for async to really show of :)
                products =  new ProductList(
                    JsonConvert.DeserializeObject<Product[]>(
                       await client.GetStringAsync("http://localhost:3000/api/product")
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
    }
}
