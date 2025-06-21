using BackgammonApp.DTOs.AppUser;
using Microsoft.AspNetCore.Mvc;

namespace BackgammonApp.Interfaces.Services
{
    public interface IAppUserService
    {
        public Task<UserProfileDTO?> GetAppUserProfileAsync();
    }
}
