using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (await _authService.Register(dto))
                return Ok(new { message = "Registration successful" });
            return BadRequest(new { message = "Username already exists" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var token = _authService.Login(dto);
            if (token == null) return Unauthorized(new { message = "Invalid username or password" });

            return Ok(new { token });
        }
    }
}
