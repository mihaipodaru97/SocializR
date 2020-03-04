using System.Collections.Generic;

namespace SocializR.Models
{
    public class ViewFriendModel
    {
        public List<FriendModel> Friends { get; set; }
        public List<FriendModel> Requests { get; set; }
    }
}
