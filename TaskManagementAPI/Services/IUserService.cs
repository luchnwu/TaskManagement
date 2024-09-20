using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public interface IUserService
    {
        Task<User> RegisterAsync(string username, string password);

        Task<User> LoginAsync(string username, string password);

        Task<bool> UserExistsAsync(string username);

        string GenerateJwtToken(User user);
    }
}
