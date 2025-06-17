using Microsoft.AspNetCore.Identity;

namespace ProgrammingClub.Services
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}
