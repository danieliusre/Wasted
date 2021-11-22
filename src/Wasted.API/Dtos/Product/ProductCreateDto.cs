using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class ProductCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        [MaxLength(10)]
        public string MeasurementUnits { get; set; }

        [Required]
        public double EnergyValue { get; set; }
    }
}
