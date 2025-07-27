using System.Threading.Tasks;
using Job_Portal.DTOs;

namespace Job_Portal.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDTO> GetDashboardStatsAsync();
    }
}
