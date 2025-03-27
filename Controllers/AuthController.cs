using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using TicketHub.Api.Models;
using TicketHub.Api.Services;

namespace TicketHub.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                return BadRequest("Password is mandatory");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            var newUser = await _authService.RegisterUserAsync(user.Email, user.PasswordHash);

            if (newUser != null)
                return BadRequest("Email already registered!");

            return Ok(new { message = "User registered with success!"});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var token = await _authService.AuthenticateAsync(loginDto.Email, loginDto.Password);

            if (token == null)
                return Unauthorized("Invalid email or password!");

            return Ok(new { token });
        }
    }

    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
