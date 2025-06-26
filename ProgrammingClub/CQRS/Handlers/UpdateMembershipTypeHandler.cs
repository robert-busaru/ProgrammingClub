using MediatR;
using ProgrammingClub.DatabaseDataContext;
using ProgrammingClub.Models;
using ProgrammingClubAPI.CQRS.Commands;

namespace ProgrammingClubAPI.CQRS.Handlers
{
    public class UpdateMembershipTypeHandler : IRequestHandler<UpdateMembershipTypeCommand, MembershipType>
    {
        private readonly ProgrammingClubDataContext _context;
        public UpdateMembershipTypeHandler(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public async Task<MembershipType> Handle(UpdateMembershipTypeCommand request, CancellationToken cancellationToken)
        {
            var membershipType = await _context.EventStatuses.FindAsync(request.Dto.IdMembershipType);
            if (membershipType == null)
            {
                throw new KeyNotFoundException($"Membership type with ID {request.Dto.IdMembershipType} not found.");
            }
            membershipType.Name = request.Dto.Name;
            membershipType.Description = request.Dto.Description;
            membershipType.SubscriptionLength = request.Dto.SubscriptionLength;
            _context.EventStatuses.Update(membershipType);
            _context.SaveChanges();
            return membershipType;
        }
    }

}
