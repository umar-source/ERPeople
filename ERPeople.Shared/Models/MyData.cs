using ERPeople.Shared.CustomValidationAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ERPeople.Shared.Models
{
    public class MyData : IValidatableObject
    {
        [CustomName("A")]
        public string Name { get; set; }

        [Required]
        [Range(18, int.MaxValue)]
        public int Age { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
             if(string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Phone))
            {
              yield  return new ValidationResult(
                    "Either Phone or Email must be specified",
                    new[] {nameof(Phone), nameof(Email)}
                    );
            }
        }
    }
}
