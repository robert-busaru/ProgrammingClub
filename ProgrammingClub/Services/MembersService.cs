using ProgrammingClub.Models;
using ProgrammingClub.Repositories;

namespace ProgrammingClub.Services
{
    public class MembersService : IMembersService
    {
        private readonly IMembersRepository _membersRepository;

        public MembersService(IMembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _membersRepository.GetAllMembersAsync();
        }

        public async Task<Member> GetMemberByIdAsync(Guid id)
        {
            return await _membersRepository.GetMemberByIdAsync(id);
        }

        public async Task AddMemberAsync(Member member)
        {
            await _membersRepository.AddMemberAsync(member);
        }

        public async Task UpdateMemberAsync(Member member)
        {
            await _membersRepository.UpdateMemberAsync(member);
        }

        public async Task DeleteMemberAsync(Guid id)
        {
            await _membersRepository.DeleteMemberAsync(id);
        }
    }
}