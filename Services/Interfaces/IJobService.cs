using Job_Portal.models;
using Job_Portal.models.enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_Portal.Services.Interfaces
{
    public interface IJobService
    {
        Task<Job> GetJobByIdAsync(int jobId);
        Task<IEnumerable<Job>> GetAllJobsAsync(string? title, string? location, JobType? jobType);
        Task<Job> AddJobAsync(Job job);
        Task DeleteJobAsync(int jobId);
        Task UpdateJobAsync(Job job);
    }
}
