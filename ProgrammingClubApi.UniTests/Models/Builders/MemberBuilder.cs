using ProgrammingClub.Models;

namespace ProgrammingClubApi.UnitTests.Models.Builders
{
    public class MemberBuilder : BuilderBase<Member>
    {
        public MemberBuilder()
        {
            _objectToBuild = new Member
            {
                IdMember = Guid.NewGuid(),
                Name = "John",
                Title = "Member",
                Position = "Developer",
                Description = "test member",
                Resume = "Resume",
                Username = "test@gmail.com",
                Password = "password123"
            };
        }
    }
}
