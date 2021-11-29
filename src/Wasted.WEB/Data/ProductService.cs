using System;
using System.Threading.Tasks;
using Serilog;
using System.Collections.Generic;


namespace Wasted.Data
{
    public class ProductService
    {

        private readonly HttpHelper _httpHelper;

        public ProductService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = null;
            try 
            {
                Log.Information("Starting to read ProductList");
                products =  new List<Product>(await _httpHelper.GetList<Product>("product"));
                Log.Information("Finished reading Productlist");
                
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return products;
        }
        public async Task<int> AddProduct(Product product)
        {
            try 
            {
                Log.Information("Starting to add product: {0}", product.Name);
                var id =  await _httpHelper.Post<Product>(product,"product");
                Log.Information("Finished adding product: {0}", product.Name);
                return id;
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return default(int);
            
        }
         public void DeleteProduct(int productId)
        {
            try 
            {
                Log.Information("Starting to delete product id: {0}", productId);
                _httpHelper.Delete(productId,"product");
                Log.Information("Finished reading Productlist");
                
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
        }
    }
}
