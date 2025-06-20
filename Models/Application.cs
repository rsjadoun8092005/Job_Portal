using Job_Portal.models.enums;

namespace Job_Portal.models
{
	public class Application
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int JobId { get; set; }
		public DateTime ApplicationDate { get; set; }
		public ApplicationStatus Status { get; set; }
	}
}