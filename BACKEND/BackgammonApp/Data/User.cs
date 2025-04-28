using Microsoft.AspNetCore.Identity;

namespace BackgammonApp.Data
{
    public class User : IdentityUser<Guid>
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required int Age { get; set; }

        public required string Role { get; set; }

        public DateTime CreatedAt { get; set; }

        // database-relations

    }
}
