using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.Shared.CustomValidationAttribute
{
    public class CustomNameAttribute : ValidationAttribute
    {
        public readonly string _startWith;        
        public CustomNameAttribute(string startWith) {

            _startWith = startWith;

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string valueString && !valueString.StartsWith(_startWith)) {
                return new ValidationResult($"{validationContext.MemberName} does not start with {_startWith}");
            }
            return ValidationResult.Success;
        }
    }
}
