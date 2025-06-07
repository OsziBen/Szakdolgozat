namespace BackgammonApp.Models.Auth
{
    public class UserRegistrationModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
    }
}
