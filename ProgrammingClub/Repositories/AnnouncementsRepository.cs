using Microsoft.EntityFrameworkCore;
using ProgrammingClub.DatabaseDataContext;
using ProgrammingClub.Models;

namespace ProgrammingClub.Repositories
{
    public class AnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;

        public AnnouncementsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public async Task AddAnnouncementAsync(Announcement announcement)
        {
            if (announcement.IdAnnouncement != Guid.Empty)
            {
                _context.Entry(announcement).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Announcement> GetAnnouncementByIdAsync(Guid id)
        {
            return await _context.Events.FirstOrDefaultAsync(a => a.IdAnnouncement == id);
        }

        public async Task<bool> AnnouncementExistsAsync(Guid id)
        {
            return await _context.Events.AnyAsync(a => a.IdAnnouncement == id);
        }

        public async Task<Announcement> UpdateAnnouncementAsync(Announcement announcement)
        {
            if (announcement.IdAnnouncement == Guid.Empty)
            {
                return null;
            }
            var exists = await AnnouncementExistsAsync(announcement.IdAnnouncement);
            if (!exists)
            {
                return null;
            }
            _context.Update(announcement);
            await _context.SaveChangesAsync();
            return announcement;
        }

        public async Task<bool> DeleteAnnouncementAsync(Guid id)
        {
            if (!await AnnouncementExistsAsync(id))
            {
                return false;
            }
            var announcement = await GetAnnouncementByIdAsync(id);
            _context.Events.Remove(announcement);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
