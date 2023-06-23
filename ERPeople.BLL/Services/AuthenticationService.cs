using ERPeople.BLL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERPeople.BLL.Services
{
    public class AuthenticationService  : IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public AuthenticationService(UserManager<IdentityUser> userManager, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

   

        public async Task<bool> LoginUser(LoginUser loginUser)
        {
            var identityUser = await _userManager.FindByEmailAsync(loginUser.Email);
            if (identityUser is null)
            {
                return false;
            }
            return await _userManager.CheckPasswordAsync(identityUser, loginUser.Password);
        }


        public async Task<bool> RegisterUser(LoginUser registerUser)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerUser.Username,
                Email = registerUser.Email
                // We not going to give password it because it create the user and let my
                //user manager to hash the password and store in the database in a secure way
            };

            var result = await _userManager.CreateAsync(identityUser, registerUser.Password);
            return result.Succeeded;
            //It means if user created successfully it will return true otherwise it will be false.
        }

   

        public string GenerateTokenString(LoginUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,"Admin"),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }

        public async Task LogoutUser()
        {
             await _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }
}
