using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___ModelValidation
{
    public class AddressValidationAttribute : ValidationAttribute
    {
        private int _minLength;
        private int _maxLength;

        public AddressValidationAttribute(int minLength, int maxLength)
        {
            _minLength = minLength;
            _maxLength = maxLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            string address = value.ToString();
            if (address.Length < _minLength || address.Length > _maxLength)
            {
                return new ValidationResult(ErrorMessage ??
                    $"地址长度应在 {_minLength} 到 {_maxLength} 之间");
            }

            // 这里可补充更多复杂验证逻辑，比如地址格式、包含特定信息等
            return ValidationResult.Success;
        }
    }
}
