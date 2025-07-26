using Job_Portal.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_Portal.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<Application> GetApplicationByIdAsync(int ApplicationId);
        Task<List<Application>> GetAllApplicationsAsync(int? userId, int? jobId);
        Task<Application> AddApplicationAsync(Application application);
        Task DeleteApplicationAsync(int applicationId);
        Task UpdateApplicationAsync(Application application);
    }
}