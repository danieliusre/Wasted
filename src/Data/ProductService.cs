using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace Wasted.Data
{
    public class ProductService
    {
        public Task<List<Product>> GetProducts()
        {
            var products =  new List<Product>();
            try 
            {
                string[] lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "DB\\ProductList.txt");
                foreach(var line in lines)
                {
                    string[] columns = line.Split(';');
                    
                    products.Add(new Product
                    {
                        Name = columns[0],
                        Type = columns[1],
                        MeasurementUnits = columns[2],
                        EnergyValue = Int32.Parse(columns[3])
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: {0}",e);
            }
            return Task.FromResult(products);
        }
    }
}
