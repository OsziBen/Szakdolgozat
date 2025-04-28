using BackgammonApp.DTOs.User;
using BackgammonApp.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackgammonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDTO>>> GetAsync()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            return user == null ? NotFound() : Ok(user);
        }

        // POST api<UserController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] UserCreateDTO data)
        {
            await _userService.CreateAsync(data);

            return NoContent();
        }

        // PUT api<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromBody] UserUpdateDTO data)
        {
            var user = await _userService.UpdateUserAsync(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _userService.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }
    }
}
