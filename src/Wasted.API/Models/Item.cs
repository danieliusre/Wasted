using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public int Amount { get; set; }

        [Required]
        public string Date { get; set; }
    }

}
