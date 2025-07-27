using System.Linq;
using System.Threading.Tasks;
using Job_Portal.DTOs;
using Job_Portal.Services.Interfaces;
using Job_Portal.Repositories.Interfaces;

namespace Job_Portal.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IApplicationRepository _applicationRepository;

        public DashboardService(IUserRepository userRepository, IJobRepository jobRepository, IApplicationRepository applicationRepository)
        {
            _userRepository = userRepository;
            _jobRepository = jobRepository;
            _applicationRepository = applicationRepository;
        }

        public async Task<DashboardDTO> GetDashboardStatsAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var jobs = await _jobRepository.GetAllAsync();
            var applications = await _applicationRepository.GetAllAsync();

            var dashboardStats = new DashboardDTO
            {
                TotalUsers = users.Count(),
                TotalJobs = jobs.Count(),
                TotalApplications = applications.Count()
            };

            return dashboardStats;
        }
    }
}
