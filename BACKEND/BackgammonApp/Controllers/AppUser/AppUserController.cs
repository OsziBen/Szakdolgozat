using BackgammonApp.DTOs.AppUser;
using BackgammonApp.Interfaces.Repositories;
using BackgammonApp.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackgammonApp.Controllers.AppUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet("UserProfile")]
        [Authorize(Roles = "Admin")]    // FONTOS! user lesz, nem admin
        public async Task<ActionResult<UserProfileDTO>> GetUserProfile()
        {
            var profile = await _appUserService.GetAppUserProfileAsync();

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }
    }
}
