using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class IngredientReadDto
    {
        public int DishId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
