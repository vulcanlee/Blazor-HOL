using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class LoginRequestDTO
    {
        [Required]
        public string Account { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
