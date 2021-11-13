using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class UserCreateDto
    {
        [Required]
        [MaxLength(20)]
        public string Login { get; set; }

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
    }
}
