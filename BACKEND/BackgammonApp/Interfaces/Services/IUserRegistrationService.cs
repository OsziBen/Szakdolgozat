using BackgammonApp.DTOs.AppUser;
using Microsoft.AspNetCore.Identity;

namespace BackgammonApp.Interfaces.Services
{
    public interface IUserRegistrationService
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDTO registrationDTO);
    }
}
