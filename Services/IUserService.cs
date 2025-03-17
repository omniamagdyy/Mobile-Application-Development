using assignment1.Models;

namespace assignment1.Services
{
    public interface IUserService
    {
        Task<string> Login(string email, string password);
        Task<string> Signup(User user);
        Task<User> GetUser(int id);
        Task<string> UpdateProfile(int id, User updatedUser);
        Task<string> UploadProfilePhoto(int id, string photoUrl);
    }
}
