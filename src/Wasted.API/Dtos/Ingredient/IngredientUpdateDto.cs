using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class IngredientUpdateDto
    {
        [Required]
        public int DishId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
