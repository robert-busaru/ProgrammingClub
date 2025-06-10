using Microsoft.AspNetCore.Mvc;
using ProgrammingClub.Models;
using ProgrammingClub.Services;
using System.Net;
using System.Threading.Tasks;

namespace ProgrammingClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementsService _announcementsService;

        public AnnouncementsController(IAnnouncementsService announcementsService)
        {
            _announcementsService = announcementsService;
        }

            // GET: api/Announcements
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var announcements = await _announcementsService.GetAllAnnouncementsAsync();
                if (!announcements.Any())
                {
                    return StatusCode((int)HttpStatusCode.OK, "No announcements found.");
                }
                return Ok(announcements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Announcements
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Announcement announcement)
        {
            try
            {
                if (announcement != null)
                {
                    await _announcementsService.AddAnnouncementAsync(announcement);
                    return StatusCode((int)HttpStatusCode.Created, "Announcement added.");
                }
                return StatusCode((int)HttpStatusCode.BadRequest, "Invalid data.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Announcements/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Announcement announcement)
        {
            try
            {
                if (announcement == null)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "Invalid data.");
                }
                var updatedAnnouncement = await _announcementsService.UpdateAnnouncementAsync(announcement);

                if (updatedAnnouncement != null)
                {
                    return StatusCode((int)HttpStatusCode.OK, "Announcement updated.");
                }

                return StatusCode((int)HttpStatusCode.NotFound, "Announcement not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Announcements/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleted = await _announcementsService.DeleteAnnouncementAsync(id);
                if (deleted)
                {
                    return StatusCode((int)HttpStatusCode.OK, "Announcement removed.");
                }
                return StatusCode((int)HttpStatusCode.NotFound, "Announcement not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
