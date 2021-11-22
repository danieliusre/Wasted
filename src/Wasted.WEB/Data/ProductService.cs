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

        private readonly HttpHelper _httpHelper;

        public ProductService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public async Task<ProductList> GetProducts()
        {
            ProductList products = null;
            try 
            {
                Log.Information("Starting to read ProductList");
                await Task.Delay(1000); 
                products =  new ProductList(await _httpHelper.GetArray<Product>("product"));
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
