using System.ComponentModel.DataAnnotations;

namespace T07_FS26_1016_ModelValidation.Models
{
    public class UserInput
    {
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Address { get; set; }

        public GenderEnum Gender { get; set; }

        [Required]
        [MinLength(6)]
        public string? Password { get; set; }

        [Phone]
        public string? Phone { get; set; }
    }
}
