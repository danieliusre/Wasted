using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Wasted.API.Models
{
    public class DishWEB
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(50)]
        public string Name { get; set; }
        public int numberOfIngredients { get; set; }
        public List<IngredientWEB> Ingredients {get; set;}

        [MaxLength(50)]
        public string Type { get; set; }
    }
}
