using System;
using System.Collections.Generic;

namespace SocializR.Models
{
    public class PostFeedModel
    {
        public UserFeedModel User;

        public List<CommentFeedModel> Comments;
        public int Id { get; set; }
        public string Body { get; set; }
        public int NumberOfLikes { get; set; }
        public DateTime CreationDate { get; set; }
        public bool CanLike { get; set; }
    }
}
