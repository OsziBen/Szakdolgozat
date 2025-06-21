using BackgammonApp.DTOs.AppUser;
using BackgammonApp.DTOs.User;
using BackgammonApp.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackgammonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;

        public AccountController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser(UserRegistrationDTO dto)
        {
            var result = await _userRegistrationService.RegisterUserAsync(dto);

            if (result.Succeeded)
            {
                return Ok("User created successfully");
            }

            return BadRequest(result.Errors);
        }

    }
}
