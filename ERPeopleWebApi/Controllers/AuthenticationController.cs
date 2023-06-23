using ERPeople.BLL.Models;
using ERPeople.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPeopleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(LoginUser loginUser)
        {
            if (await _authService.RegisterUser(loginUser))
            {
                return Ok("Successfuly done");
            }
            return BadRequest("Something went worng");
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (await _authService.LoginUser(loginUser))
            {
                var tokenString = _authService.GenerateTokenString(loginUser);

                return Ok(tokenString);
            }
            return BadRequest();
        }

   
    }
}
