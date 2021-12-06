using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Models
{
    public class FridgeItemWEB
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public string Type { get; set; }
        public string MeasurementUnits { get; set; }
        public int Amount { get; set; }
        public string Date { get; set; }
    }
}
