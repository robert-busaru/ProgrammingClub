namespace ProgrammingClub.Services
{
    public interface IMembersService
    {
        Task<Models.Member> GetMemberByIdAsync(Guid id);
        Task<IEnumerable<Models.Member>> GetAllMembersAsync();
        Task AddMemberAsync(Models.Member member);
        Task UpdateMemberAsync(Models.Member member);
        Task DeleteMemberAsync(Guid id);
    }
}
