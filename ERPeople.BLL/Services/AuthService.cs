using ERPeople.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERPeople.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IConfiguration _config;

        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly ILogger<AuthService> _logger;


        public AuthService(UserManager<IdentityUser> userManager, IConfiguration config,ILogger<AuthService> logger, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _config = config;
            _logger = logger;
            _signInManager = signInManager;
        }
       
        public async Task<UserManagerResponse> RegisterUser(RegisterViewModel loginUser)
        {
            var identityUser = new IdentityUser
            {
                UserName = loginUser.Username,
                Email = loginUser.Email
                // We not going to give password it because it create the user and let my
                //user manager to hash the password and store in the database in a secure way
            };

            var result = await _userManager.CreateAsync(identityUser, loginUser.Password);
            // return result.Succeeded;
            //It means if user created successfully it will return true otherwise it will be false.
            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");
                return new UserManagerResponse
                {
                    Message = "User created successfully!",
                    IsSuccess = true,
                };
            }

            return new UserManagerResponse
            {
                Message = "User did not created",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }


        public async Task<UserManagerResponse> LoginUser(LoginViewModel login)
        {
            var identityUser = await _userManager.FindByEmailAsync(login.Email);

            if (identityUser == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that Email address",
                    IsSuccess = false,
                };

            }

            var result = await _signInManager.CheckPasswordSignInAsync(identityUser,
                         login.Password, lockoutOnFailure: true);

            //  var result = await _userManager.CheckPasswordAsync(identityUser, login.Password);


            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                return new UserManagerResponse
                {
                    Message = "Login successfully!",
                    IsSuccess = true,
                };

            }


            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return new UserManagerResponse
                {
                    Message = "User account locked out.",
                    IsSuccess = false,
                };

            }

            return new UserManagerResponse
            {
                Message = "Invalid password",
                IsSuccess = false,
            };
        }  



        public IDictionary<string, object> GenerateToken(LoginViewModel login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, login.Email),
                new Claim(ClaimTypes.Role,"Admin"),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return new Dictionary<string, object>
                 {
                        { "token", tokenString },
                        { "expiration", securityToken.ValidTo }
                 };

        }


        public async Task<IdentityUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }


        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
        }

     

        
    }
}
