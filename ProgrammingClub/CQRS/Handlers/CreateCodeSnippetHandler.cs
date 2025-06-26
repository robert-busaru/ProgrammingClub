using MediatR;
using ProgrammingClub.CQRS.Commands;
using ProgrammingClub.DatabaseDataContext;
using ProgrammingClub.Models;

namespace ProgrammingClub.CQRS.Handlers
{
    public class CreateCodeSnippetHandler : IRequestHandler<CreateCodeSnippetCommand, Guid>
    {
        private readonly ProgrammingClubDataContext _context;
        public CreateCodeSnippetHandler(ProgrammingClubDataContext programmingClubDataContext)
        {
            _context = programmingClubDataContext;
        }

        public async Task<Guid> Handle(CreateCodeSnippetCommand request, CancellationToken cancellationToken)
        {
            var codeSnippet = new CodeSnippet
            {
                IdCodeSnippet = Guid.NewGuid(),
                Title = request.Dto.Title,
                ContentCode = request.Dto.ContentCode,
                IdSnippetPreviousVersion = request.Dto.IdSnippetPreviousVersion
            };

            _context.EventMembers.Add(codeSnippet);
            await _context.SaveChangesAsync(cancellationToken);
            return codeSnippet.IdCodeSnippet;
        }
    }

}
