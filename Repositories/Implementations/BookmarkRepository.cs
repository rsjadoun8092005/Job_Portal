using Job_Portal.Data;
using Job_Portal.models;
using Job_Portal.Repositories.Interfaces;

namespace Job_Portal.Repositories.Implementations
{
    public class BookmarkRepository : Repository<Bookmark>, IBookmarkRepository
    {
        public BookmarkRepository(AppDbContext context) : base(context)
        {
        }
    }
}