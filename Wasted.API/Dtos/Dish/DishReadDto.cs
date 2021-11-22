using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class DishReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int numberOfIngredients { get; set; }
        public string Ingredients { get; set; }
        public string Type { get; set; }
    }
}
