using Job_Portal.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_Portal.Services.Interfaces
{
    public interface IJobService
    {
        Task<Job> GetJobByIdAsync(int jobId);
        Task<List<Job>> GetAllJobsAsync();
        Task<Job> AddJobAsync(Job job);
        Task DeleteJobAsync(int jobId);
    }
}
