using System;
using System.ComponentModel.DataAnnotations;

namespace  Wasted.API.Models
{
      public class Tip
    {
        [Key]
        public int TipId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public int TipLikes { get; set; }

        [Required]
        public int TipDislikes { get; set; }

        [Required]
        [MaxLength(300)]
        public string Link { get; set; }
    }

}