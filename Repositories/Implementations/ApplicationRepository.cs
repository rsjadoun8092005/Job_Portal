using Job_Portal.Data;
using Job_Portal.models;
using Job_Portal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_Portal.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetAllAsync()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application> GetByIdAsync(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                throw new KeyNotFoundException($"Application with ID {id} was not found.");
            }
            return application;
        }

        public async Task AddAsync(Application application)
        {
            await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public void Update(Application application)
        {
            _context.Applications.Update(application);
            _context.SaveChanges();
        }

        public void Delete(Application application)
        {
            _context.Applications.Remove(application);
            _context.SaveChanges();
        }
    }
}
