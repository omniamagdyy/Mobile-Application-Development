using System.ComponentModel.DataAnnotations;

namespace assignment1.DTOs
{

    public class SignupRequest
    {
        [Required]
        public string Name { get; set; }

        public string Gender { get; set; } // Optional field

        [Required]
        [RegularExpression(@"^\d+@stud\.fci-cu\.edu\.eg$", ErrorMessage = "Invalid FCI Email format")]
        public string Email { get; set; }

        [Required]
        public string StudentID { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "Level must be between 1 and 4")]
        public int Level { get; set; } // Optional field

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*\d).{8,}$", ErrorMessage = "Password must contain at least 1 number.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
