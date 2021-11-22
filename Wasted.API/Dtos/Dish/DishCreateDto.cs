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
<<<<<<< HEAD
        public int numberOfIngredients { get; set; }

        [Required]
        [MaxLength(500)]
=======
        [MaxLength(3)]
        public int numberOfIngredients { get; set; }

        [Required]
        [MaxLength(50)]
>>>>>>> parent of cc1a163 (Revert "Dish API")
        public string Ingredients { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
    }
}
