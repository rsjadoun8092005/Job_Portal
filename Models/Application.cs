using Job_Portal.models.enums;

namespace Job_Portal.models
{
	public class Application
	{
		public int Id { get; set; }
		public DateTime ApplicationDate { get; set; }
		public ApplicationStatus Status { get; set; }


		public int UserId { get; set; }
		public User? User { get; set; } //job seeker

		public int JobId { get; set; }
		public Job? Job { get; set; } //job applied for

		public Application() { }

        public Application(int id,int userId,int jobId,DateTime applicationDate,ApplicationStatus status)
		{
			Id = id;
			UserId = userId;
			JobId = jobId;
			ApplicationDate = applicationDate;
			Status = status;
		}
    }
}