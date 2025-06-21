namespace BackgammonApp.DTOs.AppUser
{
    public class UserRegistrationDTO
    {
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string DateOfBirth { get; set; }
        public required string Password { get; set; }
    }
}
