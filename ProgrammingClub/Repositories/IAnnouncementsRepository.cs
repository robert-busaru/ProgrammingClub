using ProgrammingClub.Models;

namespace ProgrammingClub.Repositories
{
    public interface IAnnouncementsRepository
    {
        Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync();
        Task<Announcement> GetAnnouncementByIdAsync(Guid id);
        Task AddAnnouncementAsync(Announcement announcement);
        Task<bool> AnnouncementExistsAsync(Guid id);
        Task<Announcement> UpdateAnnouncementAsync(Announcement announcement);
        Task<bool> DeleteAnnouncementAsync(Guid id);
    }
}
