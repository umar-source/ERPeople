using System.ComponentModel.DataAnnotations;

namespace ERPeople.DAL.Models
{
    public class LoginUserDto
    {

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one digit, and be at least 8 characters long.")]
        public string? Password { get; set; }

    }
}
