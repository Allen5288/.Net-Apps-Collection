using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoocModel
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            if (!(value is string))
                return new ValidationResult("Type is not correct");

            var stringValue = value as string;
            if (string.IsNullOrEmpty(stringValue))
                return ValidationResult.Success;
            var result = Regex.IsMatch(stringValue, "^(\\+61|0)4\\d{8}$");
            if (result)
                return ValidationResult.Success;
            else
                return new ValidationResult("The phone number is not correct");
        }
    }
}
