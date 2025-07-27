using System.Collections.Generic;

namespace Job_Portal.DTOs
{
    public class UserDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        
        public List<JobDTO> Jobs { get; set; } = new List<JobDTO>();
        public List<ApplicationDTO> Applications { get; set; } = new List<ApplicationDTO>();
    }
}
