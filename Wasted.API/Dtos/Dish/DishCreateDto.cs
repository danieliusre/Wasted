using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class DishCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(3)]
        public int numberOfIngredients { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ingredients { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
    }
}
