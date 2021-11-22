using Wasted.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Wasted.API.Data
{
    public class SqlProductRepo : IProductRepo
    {
        private readonly WastedContext _context;

        public SqlProductRepo(WastedContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<Product> GetProductList()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void CreateNewProduct(Product product)
        {
            if (product == null){
                throw new ArgumentException(nameof(product));
            }

            _context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            //Nothing
        }

        public void DeleteProduct(Product product)
        {
            if (product == null){
                throw new ArgumentException(nameof(product));
            }

            _context.Products.Remove(product);
        }
    }
}
