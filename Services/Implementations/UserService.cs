using Job_Portal.models;
using Job_Portal.Repositories.Interfaces;
using Job_Portal.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Job_Portal.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return (await _userRepository.GetAllAsync()).ToList();
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }
    }
}
