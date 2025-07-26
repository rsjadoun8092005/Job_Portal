using Job_Portal.models;
using Job_Portal.Repositories.Interfaces;
using Job_Portal.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Job_Portal.Services.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly IRepository<Application> _applicationRepository;

        public ApplicationService(IRepository<Application> applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<Application> GetApplicationByIdAsync(int id)
        {
            return await _applicationRepository.GetByIdAsync(id);
        }

        public async Task<List<Application>> GetAllApplicationsAsync(int? userId, int? jobId)
        {
            var applications = await _applicationRepository.GetAllAsync();

            if (userId.HasValue)
            {
                applications = applications.Where(a => a.UserId == userId.Value);
            }

            if (jobId.HasValue)
            {
                applications = applications.Where(a => a.JobId == jobId.Value);
            }

            return applications.ToList();
        }

        public async Task<Application> AddApplicationAsync(Application application)
        {
            await _applicationRepository.AddAsync(application);
            return application;
        }

        public async Task DeleteApplicationAsync(int id)
        {
            await _applicationRepository.DeleteAsync(id);
        }

        public async Task UpdateApplicationAsync(Application application)
        {
            await _applicationRepository.UpdateAsync(application);
        }
    }
}
