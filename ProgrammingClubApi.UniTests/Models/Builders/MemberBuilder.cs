using ProgrammingClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Description = "test member",
                Username = "test@gmail.com",
                Title = "Member",
                Position = "Developer",
                Resume = "https://example.com/resume.pdf",
                Password = "password123"
            };
        }
    }
}
