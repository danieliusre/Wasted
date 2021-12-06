using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Models
{
    public class FridgeItem
    {
        [Key]
        public int UserId { get; set; }

        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Date { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
