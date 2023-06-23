

using ERPeople.BLL.Models;

namespace ERPeople.BLL.Services
{
    public interface IAuthenticationService
    {
        string GenerateTokenString(LoginUser loginUser);
        Task<bool> LoginUser(LoginUser loginUser);
        Task<bool> RegisterUser(LoginUser registerUser);
        Task LogoutUser();
    }
}
