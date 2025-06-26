using MediatR;
using ProgrammingClub.CQRS.Commands;
using ProgrammingClub.DatabaseDataContext;

namespace ProgrammingClub.CQRS.Handlers
{
    public class DeleteMembershipTypeHandler : IRequestHandler<DeleteMembershipTypeCommand, bool>

    {

        private readonly ProgrammingClubDataContext _context;

        public DeleteMembershipTypeHandler(ProgrammingClubDataContext context)

        {

            _context = context;

        }

        public async Task<bool> Handle(DeleteMembershipTypeCommand request, CancellationToken cancellationToken)

        {

            var membershipType = await _context.EventStatuses.FindAsync(request.IdMembershipType);

            if (membershipType == null)

            {

                return false; // Not found

            }

            _context.EventStatuses.Remove(membershipType);

            await _context.SaveChangesAsync(cancellationToken);

            return true; // Successfully deleted

        }

    }

}
