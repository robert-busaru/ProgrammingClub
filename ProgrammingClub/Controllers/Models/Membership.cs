namespace ProgrammingClub.Controllers.Models
{
    public class Membership
    {
        public Guid IdMembership { get; set; }
        public int IdMember { get; set; }
        public string IdMembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Level { get; set; }

    }
}
