using assignment1.DTOs;
using assignment1.Models;

namespace assignment1.Services
{
    public interface IAuthService
    {
        Task<string?> LoginUser(LoginRequest request);
        Task<string?> RegisterUser(SignupRequest request);
        //string GenerateJwtToken(User user);
    }
}
