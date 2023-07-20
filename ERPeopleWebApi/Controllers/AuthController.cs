using ERPeople.BLL.Services;
using ERPeople.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ERPeopleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthController(IAuthenticationService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel loginUser)
        {

            if (ModelState.IsValid)
            {

                var result = await _authService.RegisterUser(loginUser);

                if (result.IsSuccess)
                {
                    return Ok(result); // Status Code: 200 
                }

                return BadRequest(result);
            }

            return BadRequest("Invalid properties");

        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            var result = await _authService.LoginUser(login);

            if (result.IsSuccess)
            {
                var token = _authService.GenerateToken(login);
                return Ok(token);
            }
            return BadRequest("Some properties are not valid");
        }


        [Authorize]
        [HttpPost("Logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();

            return Ok();

            // return OK(); // or you can return NoContent() if you prefer
        }


        [HttpGet("Profile")]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _authService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Return the user details or map it to a specific model for the profile page
            return Ok(user);
        }
    }
}
