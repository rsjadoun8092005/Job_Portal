using Job_Portal.models.enums;

namespace Job_Portal.DTOs
{
    public class ApplicationDTO
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int JobId { get; set; }
    }
}
