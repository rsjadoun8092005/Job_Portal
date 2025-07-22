using Job_Portal.models;
using Job_Portal.Data;
using Microsoft.EntityFrameworkCore;
using Job_Portal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_Portal.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} was not found.");
            }
            return user;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChangesAsync();
        }
        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChangesAsync();
        }
    }
}
