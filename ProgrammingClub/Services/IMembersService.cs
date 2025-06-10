using ProgrammingClub.Models;
using ProgrammingClub.Models.CreateOrUpdateDTOs;

namespace ProgrammingClub.Services
{
    public interface IMembersService
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<Member> GetMemberByIdAsync(Guid id);

        Task AddMemberAsync(Member member);

        Task<Member> UpdateMemberAsync(Guid id, Member member);

        Task<Member> UpdateMemberPartiallyAsync(Guid id, UpdateMembersPartially member);

        Task<bool> DeleteMemberAsync(Guid id);
    }
}
