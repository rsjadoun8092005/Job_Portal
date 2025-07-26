using Job_Portal.models.enums;

namespace Job_Portal.models
{
	public class Job
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string CompanyName { get; set; } = string.Empty;
		public string Location { get; set; } = string.Empty;
		public DateTime PostedDate { get; set; }
        public int ApplicationsCount { get; set; } = 0;
		public JobType Type { get; set; }

        public Job() { }
        public Job(int id, string title, string description, string companyname, string location, DateTime posteddate,int applicationscount, int postedBy, JobType type)
        {
            Id = id;
            Title = title;
            Description = description;
            CompanyName = companyname;
            Location = location;
            PostedDate = posteddate;
            ApplicationsCount = applicationscount;
            Type = type;
        }

        // Foreign key to User
        public int UserId { get; set; } //job provider
        public User? User { get; set; }
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
    
	
}