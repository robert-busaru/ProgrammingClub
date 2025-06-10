using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProgrammingClub.DatabaseDataContext;
using ProgrammingClub.Models;
using ProgrammingClubApi.UnitTests.Models.Builders;

namespace ProgrammingClubApi.UnitTests.Helpers
{
    internal class DBContextHelper
    {
        public static ProgrammingClubDataContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ProgrammingClubDataContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
               .Options;


            var context = new ProgrammingClubDataContext(options);

            context.Database.EnsureCreated();

            return context;
        }

        public static async Task<Member> AddTestMember(ProgrammingClubDataContext context, Member? testMember = null)
        {
            testMember ??= new MemberBuilder().Build();
            context.Members.Add(testMember);
            await context.SaveChangesAsync();
            context.Entry(testMember).State = EntityState.Detached; // Detach to avoid tracking issues
            return testMember;
        }
    }
}
