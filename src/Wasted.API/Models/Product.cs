using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

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

        [Required]
        public Boolean AdminApproved { get; set; }
    }
}
