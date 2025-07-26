using Job_Portal.models.enums;

namespace Job_Portal.API.DTOs
{
    public class ApplicationDTO
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public ApplicationStatus Status { get; set; }
        public int UserId { get; set; }
        public int JobId { get; set; }
    }
}
