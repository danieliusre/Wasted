using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class TipCreateDto
    {
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
        [MaxLength(100)]
        public string Link { get; set; }
    }
}