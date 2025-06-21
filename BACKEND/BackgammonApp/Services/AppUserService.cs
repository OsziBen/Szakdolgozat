using BackgammonApp.DTOs.AppUser;
using BackgammonApp.Helpers.AppUserHelpers;
using BackgammonApp.Interfaces.Repositories;
using BackgammonApp.Interfaces.Services;
using BackgammonApp.Models.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BackgammonApp.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppUserService(
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserProfileDTO?> GetAppUserProfileAsync()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null
                || _httpContextAccessor.HttpContext!.User.Identity?.IsAuthenticated == false)
            {
                return null;
            }

            string? userID = user.Claims.FirstOrDefault(c => c.Type == "userID")?.Value;

            if (string.IsNullOrEmpty(userID))
            {
                return null;
            }

            var userDetails = await _userManager.FindByIdAsync(userID);

            if (userDetails == null)
            {
                return null;
            }
            var userProfile = AppUserDTOConverter.MapToDTO(userDetails);

            return userProfile;
        }
    }
}
