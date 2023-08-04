using Microsoft.AspNetCore.Mvc;
using SierraTakeHome.API.Models;
using SierraTakeHome.Core.Infrastructure.Services;

namespace SierraTakeHome.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody]UserLoginModel model)
        {
            if (await _authService.RegisterUser(model.UserName, model.Password))
                return Ok("Done");
            
            return BadRequest("Something went wrong.");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserLoginModel model)
        {
            if (await _authService.Login(model.UserName, model.Password))
            {
                var token = await _authService.GenerateTokenString(model.UserName);
                return Ok(token);
            }

            return BadRequest();
        }
    }
}
