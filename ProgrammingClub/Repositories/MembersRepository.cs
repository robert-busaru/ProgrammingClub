﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }
    }
}
