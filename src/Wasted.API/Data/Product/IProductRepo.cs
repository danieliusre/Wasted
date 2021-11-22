using Wasted.API.Models;
using System.Collections.Generic;

namespace Wasted.API.Data
{
    public interface IProductRepo
    {
        bool SaveChanges();
        IEnumerable<Product> GetProductList();
        Product GetProductById(int id);
        void CreateNewProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
