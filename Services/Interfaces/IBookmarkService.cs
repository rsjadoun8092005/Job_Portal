using Job_Portal.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_Portal.Services.Interfaces
{
    public interface IBookmarkService
    {
        Task<Bookmark> AddBookmarkAsync(Bookmark bookmark);
        Task DeleteBookmarkAsync(int userId, int jobId);
        Task<IEnumerable<Bookmark>> GetBookmarksByUserIdAsync(int userId);
    }
}
