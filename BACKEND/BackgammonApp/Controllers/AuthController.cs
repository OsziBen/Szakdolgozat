using BackgammonApp.DTOs.AppUser;
using BackgammonApp.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackgammonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task<ActionResult> SignIn([FromBody] LoginDTO dto)
        {
            var result = await _authService.SignInAsync(dto);

            if (result == null)
            {
                return BadRequest(new {message = "Username or Password is incorrect."});
            }

            return Ok(result);
        }
    }
}
