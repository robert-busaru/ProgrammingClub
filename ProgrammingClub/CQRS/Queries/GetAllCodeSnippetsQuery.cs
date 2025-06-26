using ProgrammingClub.Models;

namespace ProgrammingClub.CQRS.Queries
{
    public class GetAllCodeSnippetsQuery : MediatR.IRequest<IEnumerable<CodeSnippet>>
    {
    }
}
