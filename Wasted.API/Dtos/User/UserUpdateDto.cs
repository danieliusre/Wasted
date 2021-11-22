using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class UserUpdateDto
    {

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
        [MaxLength(20)]
        public string Role { get; set; }
    }
}
