using System.ComponentModel.DataAnnotations;

namespace BackgammonApp.DTOs.User
{
    public class UserReadDTO
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public int Age { get; set; }

        public string? Role { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
