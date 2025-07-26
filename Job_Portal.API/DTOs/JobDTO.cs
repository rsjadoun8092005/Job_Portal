using Job_Portal.models.enums;

namespace Job_Portal.API.DTOs
{
    public class JobDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime PostedDate { get; set; }
        public int ApplicationsCount { get; set; }
        public JobType Type { get; set; }
        public int UserId { get; set; }

    }
}
