using Job_Portal.DTOs;
using Job_Portal.models;
using Job_Portal.models.enums;
using Job_Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Job_Portal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDTO>>> GetAllJobs([FromQuery] string? title, [FromQuery] string? location, [FromQuery] JobType? jobType)
        {
            var jobs = await _jobService.GetAllJobsAsync(title, location, jobType);

            var jobDTOs = jobs.Select(job => new JobDTO
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                CompanyName = job.CompanyName,
                Location = job.Location,
                PostedDate = job.PostedDate,
                ApplicationsCount = job.ApplicationsCount,
                Type = job.Type.ToString(),
                UserId = job.UserId
            });

            return Ok(jobDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJobById(int id)
        {
            var job = await _jobService.GetJobByIdAsync(id);
            if (job == null) return NotFound();
            return Ok(job);
        }

        [HttpPost]
        public async Task<ActionResult<Job>> CreateJob(CreateJobDTO createJobDTO)
        {
            var newJob = new Job
            {
                Title = createJobDTO.Title,
                Description = createJobDTO.Description,
                CompanyName = createJobDTO.CompanyName,
                Location = createJobDTO.Location,
                PostedDate = DateTime.UtcNow,
                Type = createJobDTO.Type,
                UserId = createJobDTO.UserId
            };

            var created = await _jobService.AddJobAsync(newJob);
            return CreatedAtAction(nameof(GetJobById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, Job job)
        {
            if (id != job.Id) return BadRequest();

            await _jobService.UpdateJobAsync(job);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            await _jobService.DeleteJobAsync(id);
            return NoContent();
        }
    }
}
