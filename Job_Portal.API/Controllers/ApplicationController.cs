using Job_Portal.API.DTOs;
using Job_Portal.models;
using Job_Portal.Repositories.Implementations;
using Job_Portal.Repositories.Interfaces;
using Job_Portal.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_Portal.API.Controllers
{
    [ApiController]
    [Route("api/applications")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IJobRepository _jobRepository;

        public ApplicationController(IApplicationService applicationService, IJobRepository jobRepository)
        {
            _applicationService = applicationService;
            _jobRepository = jobRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationDTO>>> GetAllApplications([FromQuery] int? userId, [FromQuery] int? jobId)
        {
            var applications = await _applicationService.GetAllApplicationsAsync(userId, jobId);

            var applicationDTOs = applications.Select(app => new ApplicationDTO
            {
                Id = app.Id,
                ApplicationDate = app.ApplicationDate,
                Status = app.Status,
                UserId = app.UserId,
                JobId = app.JobId
            }).ToList();

            return Ok(applicationDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplicationById(int id)
        {
            var app = await _applicationService.GetApplicationByIdAsync(id);
            if (app == null) return NotFound();
            return Ok(app);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(CreateApplicationDTO createApplicationDTO)
        {
            var newApplication = new Application
            {
                UserId = createApplicationDTO.UserId,
                JobId = createApplicationDTO.JobId,
                ApplicationDate = DateTime.UtcNow,
            };
            var createdApplication = await _applicationService.AddApplicationAsync(newApplication);

            var job = await _jobRepository.GetByIdAsync(createApplicationDTO.JobId);
            if (job != null)
            {
                job.ApplicationsCount++;
                await _jobRepository.UpdateAsync(job);
            }

            var applicationDTO = new ApplicationDTO
            {
                Id = createdApplication.Id,
                ApplicationDate = createdApplication.ApplicationDate,
                Status = createdApplication.Status,
                UserId = createdApplication.UserId,
                JobId = createdApplication.JobId
            };

            return CreatedAtAction(nameof(GetApplicationById), new { id = applicationDTO.Id }, applicationDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication(int id, Application app)
        {
            if (id != app.Id) return BadRequest();
            await _applicationService.UpdateApplicationAsync(app);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            await _applicationService.DeleteApplicationAsync(id);
            return NoContent();
        }
    }
}
