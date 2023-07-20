
using ERPeople.Shared.Models;
using Microsoft.AspNetCore.Identity;


namespace ERPeople.BLL.Services
{
    public interface IAuthenticationService
    {
        IDictionary<string, object> GenerateToken(LoginViewModel login);
        Task<UserManagerResponse> LoginUser(LoginViewModel login);
        Task<UserManagerResponse> RegisterUser(RegisterViewModel register);

        Task Logout();

        Task<IdentityUser> GetUserByEmail(string email);

    }
}
