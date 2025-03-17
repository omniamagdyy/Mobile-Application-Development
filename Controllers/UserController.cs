using assignment1.Models;
using assignment1.Services;
using Microsoft.AspNetCore.Mvc;

namespace assignment1.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) { _userService = userService; }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id) => Ok(await _userService.GetUser(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] User user) => Ok(await _userService.UpdateProfile(id, user));

        [HttpPost("{id}/photo")]
        public async Task<IActionResult> UploadPhoto(int id, [FromBody] string photoUrl) => Ok(await _userService.UploadProfilePhoto(id, photoUrl));
    }
}
