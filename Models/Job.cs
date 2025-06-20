using Job_Portal.models.enums;

namespace Job_Portal.models
{
	public class Job
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string CompanyName { get; set; }
		public string Location { get; set; }
		public DateTime PostedDate { get; set; }
		public int ApplicationsCount { get; set; }
		public int PostedBy { get; set; }
		public JobType Type { get; set; }
	}
}