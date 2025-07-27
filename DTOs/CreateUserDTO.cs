using System.ComponentModel.DataAnnotations;
using Job_Portal.models.enums;

namespace Job_Portal.DTOs
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required.")]
        public UserRole Role { get; set; }
    }
}
