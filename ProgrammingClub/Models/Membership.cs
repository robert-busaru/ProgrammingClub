using System.ComponentModel.DataAnnotations;

namespace ProgrammingClub.Models
{
    public class Membership
    {
        [Key]
        public Guid IdMembership { get; set; }
        public int IdMember { get; set; }
        public string IdMembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Level { get; set; }

    }
}
