using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Wasted.API.Dtos
{
    public class DishCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int numberOfIngredients { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
    }
}
