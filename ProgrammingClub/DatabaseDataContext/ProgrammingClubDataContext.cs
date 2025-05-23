using Microsoft.EntityFrameworkCore;

namespace ProgrammingClub.DatabaseDataContext
{
    public class ProgrammingClubDataContext: DbContext
    {

        public ProgrammingClubDataContext(DbContextOptions<ProgrammingClubDataContext> options) : base(options)
        {
        }
        public DbSet<Models.Member> Members { get; set; } = null!;
        public DbSet<Models.Announcement> Events { get; set; } = null!;
        public DbSet<Models.CodeSnippet> EventMembers { get; set; } = null!;
        public DbSet<Models.Membership> EventTypes { get; set; } = null!;
        public DbSet<Models.MembershipType> EventStatuses { get; set; } = null!;
    }
}
