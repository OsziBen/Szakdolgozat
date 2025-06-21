using BackgammonApp.DTOs.AppUser;
using BackgammonApp.Models.User;

namespace BackgammonApp.Helpers.AppUserHelpers
{
    public class AppUserDTOConverter
    {
        public static UserProfileDTO MapToDTO(AppUser user) => new()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            DateOfBirth = user.DateOfBirth
        };
    }
}
