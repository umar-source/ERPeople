

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ERPeople.BLL.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be between 1 and 50 characters.", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters.", MinimumLength = 1)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(100, ErrorMessage = "Address must be between 1 and 100 characters.", MinimumLength = 1)]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "City must be between 1 and 50 characters.", MinimumLength = 1)]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "State must be between 1 and 50 characters.", MinimumLength = 1)]
        public string State { get; set; }

        [StringLength(10, ErrorMessage = "Postal code must be between 1 and 10 characters.", MinimumLength = 1)]
        public string PostalCode { get; set; }
    }
}
