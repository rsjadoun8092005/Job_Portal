using Job_Portal.models.enums;

namespace Job_Portal.API.DTOs
{
    public class CreateJobDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public JobType Type { get; set; }
        public int UserId { get; set; }

    }
}
