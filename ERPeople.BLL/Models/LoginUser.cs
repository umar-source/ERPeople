using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.BLL.Models
{
    public class LoginUser
    {

        [StringLength(12, ErrorMessage = "First name must be between 4 and 12 characters.", MinimumLength = 4)]
        public string? Username { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one digit, and be at least 8 characters long.")]
        public string? Password { get; set; }
    }
}
