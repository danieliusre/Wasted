using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }

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
