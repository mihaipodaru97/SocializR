namespace BusinessEntities.Entities
{
    public partial class FriendRequest
    {
        public int UserFromId { get; set; }
        public int UserToId { get; set; }

        public User UserFrom { get; set; }
        public User UserTo { get; set; }
    }
}
