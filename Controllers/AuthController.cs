using assignment1.DTOs;
using assignment1.Models;
using assignment1.Services;
using Microsoft.AspNetCore.Mvc;

namespace assignment1.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public AuthController(IUserService userService,IAuthService authService)
        {
            _userService = userService;
            _authService = authService;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.LoginUser(request);

            if (token == null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(new { message = "Login Successful", token = token });
        }


        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterUser(request);
            if (result == "Email already exists.")
            {
                return Conflict(new { message = result });
            }

            return Ok(new { message = result });
        }
    }
}



