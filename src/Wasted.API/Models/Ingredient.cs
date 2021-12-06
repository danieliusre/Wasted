using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wasted.API.Models
{
    public class Ingredient
    {
        [Key]
        [Column(Order=0)]
        public int DishId { get; set; }

        [Key, Column(Order=1)]
        public int ProductId { get; set; }
        
        public int Amount { get; set; }
    }

}
