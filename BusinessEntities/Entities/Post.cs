using System;
using System.Collections.Generic;

namespace BusinessEntities.Entities
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public int NumberOfLikes { get; set; }
        public DateTime CreationDate { get; set; }

        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
