using Microsoft.EntityFrameworkCore;
using ProgrammingClub.DatabaseDataContext;
using ProgrammingClub.Models;

namespace ProgrammingClub.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private readonly ProgrammingClubDataContext _context;

        public MembersRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member?> GetMemberByIdAsync(Guid id)
        {
            return await _context.Members.FindAsync(id);
        }

        public async Task<Member> AddMemberAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<Member> UpdateMemberAsync(Member member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<bool> DeleteMemberAsync(Guid id) // Updated to match the interface
        {
            if (!await MemberExistsAsync(id))
            {
                return false;
            }

            _context.Members.Remove(new Member { IdMember = id });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MemberExistsAsync(Guid id)
        {
            return await _context.Members.AnyAsync(m => m.IdMember == id);
        }
    }
}
