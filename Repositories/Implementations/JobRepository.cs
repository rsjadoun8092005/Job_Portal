using Job_Portal.Data;
using Job_Portal.models;
using Job_Portal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_Portal.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job> GetByIdAsync(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                throw new KeyNotFoundException($"Job with ID {id} was not found.");
            }
            return job;
        }

        public async Task AddAsync(Job job)
        {
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public void Update(Job job)
        {
            _context.Jobs.Update(job);
            _context.SaveChanges();
        }

        public void Delete(Job job)
        {
            _context.Jobs.Remove(job);
            _context.SaveChanges();
        }
    }
}
