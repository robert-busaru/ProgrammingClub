namespace ProgrammingClub.Controllers.Models
{
    public class MembershipType
    {
        public Guid IdMembershipType {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubscriptionLength { get; set; }
    }
}
