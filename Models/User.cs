using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment1.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public string? Gender { get; set; } // Optional field

        [Required(ErrorMessage = "FCI Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [RegularExpression(@"^(\d+)@stud\.fci-cu\.edu\.eg$", ErrorMessage = "Invalid FCI Email format. Example: studentID@stud.fci-cu.edu.eg")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Student ID is required.")]
        public string StudentID { get; set; }

        [Range(1, 4, ErrorMessage = "Level must be 1, 2, 3, or 4.")]
        public int? Level { get; set; } // Optional field

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@".*\d.*", ErrorMessage = "Password must contain at least one number.")]
        [NotMapped] // Not stored in the DB (used only for validation)
        public string Password { get; set; }

        public string PasswordHash { get; set; } // This is what gets stored in the DB

        public string? ProfilePhoto { get; set; } // Optional field
    }
}
