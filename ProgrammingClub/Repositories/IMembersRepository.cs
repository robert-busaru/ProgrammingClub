namespace ProgrammingClub.Repositories
{
    public interface IMembersRepository
    {

        Task<Models.Member> GetMemberByIdAsync(int id);
        Task<IEnumerable<Models.Member>> GetAllMembersAsync();
        //Task AddMemberAsync(Models.Member member);
        //Task UpdateMemberAsync(Models.Member member);
        //Task DeleteMemberAsync(int id);

    }
}
