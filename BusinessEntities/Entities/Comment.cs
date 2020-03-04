using System;

namespace BusinessEntities.Entities
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }
    }
}
