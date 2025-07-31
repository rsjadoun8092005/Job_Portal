using Job_Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Job_Portal.Mvc.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly IApplicationService _applicationService;
        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task<IActionResult> Index(int? userId = null, int? jobId = null)
        {
            var applications = await _applicationService.GetAllApplicationsAsync(userId,jobId);
            return View(applications);
        }
    }
}
