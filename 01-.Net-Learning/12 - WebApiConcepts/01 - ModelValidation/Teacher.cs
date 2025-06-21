using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___ModelValidation
{
    public class Teacher : User
    {
        [Required(ErrorMessage = "teacher name can't be null")]
        public override string? UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^(\([0-9]\))?\s?\d{4}?\s?\d{4}|[0-9]\)?\s?\d{4}\s?\d{4}|04\d{2}\s?\d{3}\s?\d{3}$",
             ErrorMessage = "Phone number format is invalid")]
        public string PhoneNum { get; set; }

        [MaxLength(10, ErrorMessage = "max length is 10")]
        public string Description { get; set; }

        [AddressValidation(10, 15)]
        public string Address { get; set; }
    }
}
