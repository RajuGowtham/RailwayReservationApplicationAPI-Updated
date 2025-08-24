using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railway_Reservation_API_Project.Models;
using Railway_Reservation_API_Project.Repositories;

namespace Railway_Reservation_API_Project.Controllers
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


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            // Logic to get all users
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            // Logic to get a user by ID
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            // Logic to create a new user
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }
            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            // Logic to update an existing user
            if (user == null || user.UserId <= 0)
            {
                return BadRequest("Invalid user data");
            }
            var updatedUser = await _userService.UpdateUserAsync(user);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // Logic to delete a user
            if (id <= 0)
            {
                return BadRequest("Invalid user ID");
            }
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
