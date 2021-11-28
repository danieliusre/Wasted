using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class TipUpdateDto
    {
        [MaxLength(50)]
        public string TipName { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public int TipLikes { get; set; }

        [Required]
        public int TipDislikes { get; set; }

        [MaxLength(300)]
        public string Link { get; set; }
    }
}
