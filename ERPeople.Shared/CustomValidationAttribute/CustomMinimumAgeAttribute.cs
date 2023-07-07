
using System.ComponentModel.DataAnnotations;

namespace ERPeople.Shared.CustomValidationAttribute
{
    public  class CustomMinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public CustomMinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                var age = DateTime.Today.Year - dateOfBirth.Year;
                if (age < _minimumAge)
                {
                     return new ValidationResult($"Must be at least {_minimumAge} years old.");
                }
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid date of birth.");
        }
    }
}
