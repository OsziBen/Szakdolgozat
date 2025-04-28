using System.ComponentModel.DataAnnotations;

namespace BackgammonApp.DTOs.User
{
    public class UserUpdateDTO
    {
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [Range(0, 150, ErrorMessage = "Age must be between 0 and 150")]
        public required int Age { get; set; }
    }
}
