using Job_Portal.models.enums;

namespace Job_Portal.DTOs
{
    public class CreateApplicationDTO
    {
        public int UserId { get; set; }
        public int JobId { get; set; }
    }
}
