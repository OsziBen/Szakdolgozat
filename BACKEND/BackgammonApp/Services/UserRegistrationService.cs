using BackgammonApp.DTOs.AppUser;
using BackgammonApp.Interfaces.Services;
using BackgammonApp.Models.User;
using Microsoft.AspNetCore.Identity;

namespace BackgammonApp.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRegistrationService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(UserRegistrationDTO registrationDTO)
        {
            var user = new AppUser
            {
                UserName = registrationDTO.Email,
                Email = registrationDTO.Email,
                FirstName = registrationDTO.FirstName,
                LastName = registrationDTO.LastName,
                DateOfBirth = DateOnly.Parse(registrationDTO.DateOfBirth),
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, registrationDTO.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");       // USER lesz!
            }

            return result;
        }
    }
}
