using ProgrammingClub.Models;

namespace ProgrammingClub.Repositories
{
    public class MembersRepository : IMembersRepository
    {

        Task<IEnumerable<Member>> IMembersRepository.GetAllMembersAsync()
        {
            throw new NotImplementedException();
        }

        Task<Member> IMembersRepository.GetMemberByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
