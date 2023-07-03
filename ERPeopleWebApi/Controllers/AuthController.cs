using ERPeople.BLL.Services;
using ERPeople.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ERPeopleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthController(IAuthenticationService authService)
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

            return BadRequest("Some properties are not valid"); 
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginUser(login);  

                if (result.IsSuccess)
                {
                    var tokenString = _authService.GenerateTokenString(login);

                    return Ok(tokenString);
                }

                return BadRequest(result);
            }
           
                return BadRequest("Some properties are not valid");    
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
