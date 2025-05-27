namespace ProgrammingClub.Repositories
{
    public interface IMembersRepository
    {

        public Task<Models.Member> GetMemberByIdAsync(int id);
        public Task<IEnumerable<Models.Member>> GetAllMembersAsync();
        //Task AddMemberAsync(Models.Member member);
        //Task UpdateMemberAsync(Models.Member member);
        //Task DeleteMemberAsync(int id);

    }
}
