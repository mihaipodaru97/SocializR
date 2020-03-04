namespace BusinessEntities.Entities
{
    public partial class UserInterest
    {
        public int UserId { get; set; }
        public int InterestId { get; set; }

        public Interest Interest { get; set; }
        public User User { get; set; }
    }
}
