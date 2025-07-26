using Job_Portal.models.enums;

namespace Job_Portal.API.DTOs
{
    public class CreateApplicationDTO
    {
        public int UserId { get; set; }
        public int JobId { get; set; }
    }
}
