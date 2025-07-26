using Job_Portal.models;
using Job_Portal.Repositories.Interfaces;
using Job_Portal.Services.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Job_Portal.Services.Implementations
{
    public class BookmarkService : IBookmarkService
    {  
        private readonly IBookmarkRepository _bookmarkRepository;
        public BookmarkService(IBookmarkRepository bookmarkRepository)
        {
            _bookmarkRepository = bookmarkRepository;
        }
        public async Task<Bookmark> AddBookmarkAsync(Bookmark bookmark)
        {
            return await _bookmarkRepository.AddAsync(bookmark);
        }
        public async Task DeleteBookmarkAsync(int userId, int jobId)
        {
            var bookmarks = await _bookmarkRepository.GetAllAsync();
            var bookmarkToDelete = bookmarks.FirstOrDefault(b => b.UserId == userId && b.JobId == jobId);
            if (bookmarkToDelete != null)
            {
                await _bookmarkRepository.DeleteAsync(bookmarkToDelete.Id);
            }
        }
        public async Task<IEnumerable<Bookmark>> GetBookmarksByUserIdAsync(int userId)
        {
            var bookmarks = await _bookmarkRepository.GetAllAsync();
            return bookmarks.Where(b => b.UserId == userId);
        }
    }
}
