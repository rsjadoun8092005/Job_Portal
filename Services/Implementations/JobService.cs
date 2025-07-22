using Job_Portal.models;
using Job_Portal.Repositories.Implementations;
using Job_Portal.Repositories.Interfaces;
using Job_Portal.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_Portal.Services.Implementations
{
    public class JobService : IJobService
        {
        private readonly IRepository<Job> _jobRepository;
        public JobService(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task<Job> GetJobByIdAsync(int id)
        {
            return await _jobRepository.GetByIdAsync(id);
        }
        public async Task<List<Job>> GetAllJobsAsync()
        {
            List<Job> jobs = (await _jobRepository.GetAllAsync()).ToList();
            return jobs;
        }
        public async Task<Job> AddJobAsync(Job job)
        {
            await _jobRepository.AddAsync(job);
            return job;
        }
        public async Task DeleteJobAsync(int jobId)
        {
            await _jobRepository.DeleteAsync(jobId);
        }
    }
}
