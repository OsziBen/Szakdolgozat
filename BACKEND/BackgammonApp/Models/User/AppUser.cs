using Microsoft.AspNetCore.Identity;

namespace BackgammonApp.Models.User
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }

        public DateTime CreatedAt { get; set; }

        // database-relations

    }
}
