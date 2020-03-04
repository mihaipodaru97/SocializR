namespace BusinessEntities.Entities
{
    public partial class Like
    {
        public int UserId { get; set; }
        public int PostId { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }
    }
}
