using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; }
    }
}
