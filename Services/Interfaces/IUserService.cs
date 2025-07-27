using Job_Portal.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_Portal.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<List<User>> GetAllUsersAsync();
        Task<User> AddUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task UpdateUserAsync(User user);
        Task<User?> LoginAsync(string email, string password);
    }
}
