using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted.API.Dtos
{
    public class UserReadDto
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
