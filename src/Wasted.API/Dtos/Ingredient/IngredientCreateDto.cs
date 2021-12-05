using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class IngredientCreateDto
    {
        [Required]
        public int DishId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public int Amount { get; set; }
    }
}
