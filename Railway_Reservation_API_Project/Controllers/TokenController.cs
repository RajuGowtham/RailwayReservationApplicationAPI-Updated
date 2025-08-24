using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Railway_Reservation_API_Project.Interfaces;
using Railway_Reservation_API_Project.Models;

namespace Railway_Reservation_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly RailwayReservationContext _con;

        private readonly ITokenGenerate _tokenService;

        public TokenController(RailwayReservationContext con, ITokenGenerate tokenService)
        {
            _con = con;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User userData)
        {
            if (userData != null && !string.IsNullOrEmpty(userData.UserName) &&
            !string.IsNullOrEmpty(userData.PasswordHash))
            {
                var user = await GetUser(userData.UserName, userData.PasswordHash, userData.Role);

                if (user != null)
                {
                    var token = _tokenService.GenerateToken(user);
                    return Ok(new { token = token });
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest("Invalid request data");
            }

        }

        private async Task<User> GetUser(string name, string password, string role)
        {
            return await _con.Users.FirstOrDefaultAsync(u => u.UserName == name &&
            u.PasswordHash == password && u.Role == role) ?? new Models.User();
        }
    }
}
