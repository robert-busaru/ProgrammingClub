namespace ProgrammingClub.Repositories
{
    public interface IMembersRepository
    {

        public Task<Models.Member> GetMemberByIdAsync(Guid id);
        public Task<IEnumerable<Models.Member>> GetAllMembersAsync();
        public Task<Models.Member> AddMemberAsync(Models.Member member);
        public Task<Models.Member> UpdateMemberAsync(Models.Member member);
        public Task<bool> DeleteMemberAsync(Guid id);

    }
}
