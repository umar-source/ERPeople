using ERPeople.Shared.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPeople.BLL.Services
{
    public interface IAuthenticationService
    {
        string GenerateTokenString(LoginViewModel login);
        Task<UserManagerResponse> LoginUser(LoginViewModel login);
        Task<UserManagerResponse> RegisterUser(RegisterViewModel register);

        Task<IdentityUser> GetUserByEmail(string email);


    }
}
