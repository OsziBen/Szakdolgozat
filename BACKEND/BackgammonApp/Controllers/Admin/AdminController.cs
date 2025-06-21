using BackgammonApp.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackgammonApp.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("AdminOnly")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnly()
        {
            var result = _adminService.GetAdminMessage();

            return Ok(result);
        }
    }
}
