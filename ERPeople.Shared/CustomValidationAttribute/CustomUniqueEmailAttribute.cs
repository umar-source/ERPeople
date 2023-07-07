using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ERPeople.Shared.CustomValidationAttribute
{
    public class CustomUniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

         /*
          
            if (value is string email && new EmailAddressAttribute().IsValid(email))
            {
                // Get the database context
                var dbContext = validationContext.GetService<YourDbContext>();

                // Perform a query to check if the email exists
                var existingEmail =  dbContext.Users.FirstOrDefault(u => u.Email == email);

                if (existingEmail != null)
                {
                    return new ValidationResult("Email already exists.");
                }

                return ValidationResult.Success;
            }

         */

            return new ValidationResult("Invalid email address.");
        }
    }
}
