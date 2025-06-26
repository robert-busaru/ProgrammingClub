using MediatR;
using ProgrammingClub.CQRS.Commands;
using ProgrammingClub.DatabaseDataContext;
using ProgrammingClub.Models;

namespace ProgrammingClub.CQRS.Handlers
{
    public class CreateMembershipTypeHandler : IRequestHandler<CreateMembershipTypeCommand, Guid>
    {
        private readonly ProgrammingClubDataContext _context;
        public CreateMembershipTypeHandler(ProgrammingClubDataContext programmingClubDataContext) 
        {
            _context = programmingClubDataContext;
        }

        public async Task<Guid> Handle(CreateMembershipTypeCommand request, CancellationToken cancellationToken)
        {
            var membershipType = new MembershipType
            {
                IdMembershipType = Guid.NewGuid(),
                Name = request.Dto.Name,
                Description = request.Dto.Description,
                SubscriptionLength = request.Dto.SubscriptionLength
            };

            _context.EventStatuses.Add(membershipType);
            await _context.SaveChangesAsync(cancellationToken);
            return membershipType.IdMembershipType;
        }
    }
}
