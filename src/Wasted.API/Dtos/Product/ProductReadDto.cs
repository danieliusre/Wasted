using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string MeasurementUnits { get; set; }
        public double EnergyValue { get; set; }
    }
}
