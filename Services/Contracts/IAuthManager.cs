using ReactMVC.Models;

namespace ReactMVC.Services.Contracts
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDto loginDto);
        Task<string> CreateToken();
    }
}
