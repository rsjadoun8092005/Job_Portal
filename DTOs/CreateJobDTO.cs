using System.ComponentModel.DataAnnotations;
using Job_Portal.models.enums;

namespace Job_Portal.DTOs
{
    public class CreateJobDTO
    {
        [Required(ErrorMessage = "Job title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Job description is required.")]
        [MinLength(20, ErrorMessage = "Description must be at least 20 characters long.")]
        public string Description { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Job type is required.")]
        public JobType Type { get; set; }

        public int UserId { get; set; }

    }
}
