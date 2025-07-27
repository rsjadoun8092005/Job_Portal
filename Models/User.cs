using Job_Portal.models.enums;

namespace Job_Portal.models
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
		public UserRole Role { get; set; }

        public User() { }
        public User(int id, string name, string email, UserRole role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }

        public ICollection<Job> Jobs { get; set; } = new List<Job>(); //job provider
        public ICollection<Application> Applications { get; set; } = new List<Application>(); //job seeker
    }

}