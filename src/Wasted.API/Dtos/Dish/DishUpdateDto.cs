using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class DishUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int numberOfIngredients { get; set; }

        // [Required]
        // [MaxLength(500)]
        // public string Ingredients { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
    }
}
