using Job_Portal.models;
using Job_Portal.models.enums;
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
        public async Task<IEnumerable<Job>> GetAllJobsAsync(string? title, string? location, JobType? jobType)
        {
            var jobs = await _jobRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(title))
            {
                jobs = jobs.Where(j => j.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(location))
            {
                jobs = jobs.Where(j => j.Location.Contains(location, StringComparison.OrdinalIgnoreCase));
            }

            if (jobType.HasValue)
            {
                jobs = jobs.Where(j => j.Type == jobType.Value);
            }

            return jobs.ToList();
        }
        public async Task<Job> AddJobAsync(Job job)
        {
            await _jobRepository.AddAsync(job);
            return job;
        }
        public async Task UpdateJobAsync(Job job)
        {
            await _jobRepository.UpdateAsync(job);
            await Task.CompletedTask;
        }
        public async Task DeleteJobAsync(int jobId)
        {
            await _jobRepository.DeleteAsync(jobId);
        }
    }
}
