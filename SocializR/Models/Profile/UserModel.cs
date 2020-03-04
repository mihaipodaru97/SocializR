using System;
using System.Collections.Generic;

namespace SocializR.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> InterestsNames { get; set; }
        public List<AlbumModel> Albums { get; set; }
        public bool FriendRequestSent { get; set; }
        public bool Friends { get; set; }
        public bool CanSeeProfile { get; set; }
    }
}
