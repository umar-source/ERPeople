using ERPeople.Shared.CustomValidationAttribute;
using System.ComponentModel.DataAnnotations;

namespace ERPeople.DAL.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed {1} characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed {1} characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; set; }

        [CustomMinimumAge(18, ErrorMessage = "Must be at least 18 years old.")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

     

        [Required(ErrorMessage = "DepartmentId is required.")]
        public int DepartmentId { get; set; }

        public virtual ICollection<Department>? Departments { get; set; }

        public virtual ICollection<Attendance>? Attendances { get; set; }
    }
}
