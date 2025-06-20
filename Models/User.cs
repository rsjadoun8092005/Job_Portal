using Job_Portal.models.enums;

namespace Job_Portal.models
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public UserRole Role { get; set; }
	}
}