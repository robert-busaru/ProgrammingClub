using AutoMapper;
using ProgrammingClub.Models;
using ProgrammingClub.Repositories;

namespace ProgrammingClub.Services
{
    public class AnnouncementsSerivce : IAnnouncementsService
    {
        private readonly IAnnouncementsRepository _announcementsRepository;
        private readonly IMapper _mapper;

        public AnnouncementsSerivce(IAnnouncementsRepository announcementsRepository, IMapper mapper)
        {
            _announcementsRepository = announcementsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync()
        {
            return await _announcementsRepository.GetAllAnnouncementsAsync();
        }

        public async Task<Announcement> GetAnnouncementByIdAsync(Guid id)
        {
            return await _announcementsRepository.GetAnnouncementByIdAsync(id);
        }
        public async Task AddAnnouncementAsync(Announcement announcement)
        {
            if (await _announcementsRepository.AnnouncementExistsAsync(announcement.IdAnnouncement))
            {
                throw new ArgumentException("Announcement already exists.", nameof(announcement.Title));
            }
            announcement.IdAnnouncement = Guid.NewGuid();
            await _announcementsRepository.AddAnnouncementAsync(announcement);
        }

        public async Task<bool> AnnouncementExistsAsync(Guid id)
        {
            return await _announcementsRepository.AnnouncementExistsAsync(id);
        }

        public async Task<Announcement> UpdateAnnouncementAsync(Announcement announcement)
        {
            if (!await _announcementsRepository.AnnouncementExistsAsync(announcement.IdAnnouncement))
            {
                return null;
            }
            return await _announcementsRepository.UpdateAnnouncementAsync(announcement);
        }

        public async Task<bool> DeleteAnnouncementAsync(Guid id)
        {
            if (!await _announcementsRepository.AnnouncementExistsAsync(id))
            {
                return false;
            }
            return await _announcementsRepository.DeleteAnnouncementAsync(id);
        }
    }
}
