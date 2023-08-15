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
        private readonly IAuthService _authService;

        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel loginUser)
        {

            try {
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
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e}");
            }

        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            try
            {
                var result = await _authService.LoginUser(login);

                if (result.IsSuccess)
                {
                    var token = _authService.GenerateToken(login);
                    return Ok(token);
                }
                return BadRequest("Some properties are not valid");
            }
            catch (Exception e) 
            {
                return StatusCode(500, $"Internal server error: {e}");
            }
           
        }


        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _authService.Logout();

                return Ok();

                // return OK(); // or you can return NoContent() if you prefer
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e}");
            }
            finally
            {


            }
        }


        [HttpGet("Profile")]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
  
            try
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                if (email == null)
                {
                    return NotFound("Email not found");
                }
                var user = await _authService.GetUserByEmail(email);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                // Return the user details or map it to a specific model for the profile page
                return Ok(user);
            }
            catch(Exception e) 
            {
                return StatusCode(500, $"Internal server error: {e}");
            }
         
        }
    }
}
