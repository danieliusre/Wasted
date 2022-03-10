using System;
using System.Threading.Tasks;
using Serilog;
using System.Collections.Generic;
using Wasted.WEB.Wrapped;

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
                products =  new List<Product>(await _httpHelper.GetProductList<Product>("product"));
                Log.Information("Finished reading Productlist");
                
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return products;
        }

        public List<String> GetMeasurementUnits()
        {
            List<String> measurementUnits = new List<String>
            {
                "Grams(g)",
                "Kilogram (kg)",
                "Litre(l)",
                "Mililitre(ml)",
                "Unit(s)"
            };

            return measurementUnits;
        }
        public async Task<List<Product>> GetProducts(string link)
        {
            List<Product> products = null;
            try 
            {
                Log.Information("Starting to read ProductList");
                products =  new List<Product>(await _httpHelper.GetProductList<Product>(link));
                Log.Information("Finished reading Productlist");
                
            }
            catch (Exception e)
            {
                Log.Error("Exception caught: {0}",e);
            }
            return products;
        }
        public async Task<List<Product>> GetAllProducts(int totalRecords)
        {
            List<Product> products = null;
            try 
            {
                Log.Information("Starting to read ProductList");
                string link = "product?pageNumber=1&pageSize=" + totalRecords;
                products =  new List<Product>(await _httpHelper.GetProductList<Product>(link));
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
        public async Task<PagedResponse<List<Product>>> GetResponse()
        {
            var result =  await _httpHelper.GetPageResponse("product");
            return result;
        }

        public async Task<PagedResponse<List<Product>>> GetResponse(string link)
        {
            var result =  await _httpHelper.GetPageResponse(link);
            return result;
        }
    }
}
