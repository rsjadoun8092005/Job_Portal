namespace Job_Portal.models
{
    public class Bookmark
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JobId { get; set; }

        public User? User { get; set; }
        public Job? Job { get; set; }
        public Bookmark() { }
        public Bookmark(int userId, int jobId)
        {
            UserId = userId;
            JobId = jobId;
        }
    }
}
