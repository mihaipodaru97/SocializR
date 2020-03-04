using System;

namespace SocializR.Models
{
    public class CommentFeedModel
    {
        public UserFeedModel User;
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
    }
}