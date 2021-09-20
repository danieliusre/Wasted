using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace Wasted.Data
{
    public class ProductService
    {
        public Task<List<Product>> GetProductsAsync()
        {
            var products =  new List<Product>();
            string[] lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "DB\\ProductList.txt");
            foreach(var line in lines)
            {
                string[] columns = line.Split(';');
                
                products.Add(new Product
                {
                    Name = columns[0],
                    Type = columns[1],
                    MeasurementUnits = columns[2],
                    EnergyValue = columns[3]
                });
            }
            return Task.FromResult(products);
        }
    }
}
