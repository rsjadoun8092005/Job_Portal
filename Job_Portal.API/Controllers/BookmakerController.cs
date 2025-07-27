using Job_Portal.DTOs;
using Job_Portal.models;
using Job_Portal.Repositories.Interfaces;
using Job_Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Job_Portal.API.Controllers
{
    [ApiController]
    [Route("api/bookmarks")]
    public class BookmarksController : ControllerBase
    {
        private readonly IBookmarkService _bookmarkService;
        public BookmarksController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBookmark([FromBody] CreateBookmarkDTO createBookmarkDTO)
        {
            var newBookmark = new Bookmark
            {
                UserId = createBookmarkDTO.UserId,
                JobId = createBookmarkDTO.JobId
            };

            var createdBookmark = await _bookmarkService.AddBookmarkAsync(newBookmark);
            return Ok(createdBookmark);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookmark([FromQuery] int userId, [FromQuery] int jobId)
        {
            await _bookmarkService.DeleteBookmarkAsync(userId, jobId);
            return NoContent();
        }
    }
}
