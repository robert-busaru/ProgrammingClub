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
            // Ensure the method returns the result of the repository call
            return await _membersRepository.GetAllMembersAsync();
        }

        public Task<Member> GetMemberByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
