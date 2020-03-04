using System;
using System.Collections.Generic;

namespace BusinessEntities.Entities
{
    public partial class User
    {
        public User()
        {
            Albums = new HashSet<Album>();
            Comments = new HashSet<Comment>();
            FriendRequestsUserFrom = new HashSet<FriendRequest>();
            FriendRequestsUserTo = new HashSet<FriendRequest>();
            FriendsUser1 = new HashSet<Friend>();
            FriendsUser2 = new HashSet<Friend>();
            Likes = new HashSet<Like>();
            Posts = new HashSet<Post>();
            UserInterest = new HashSet<UserInterest>();
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public int CountyId { get; set; }
        public int LocalityId { get; set; }
        public bool Gender { get; set; }
        public bool Privacy { get; set; }
        public DateTime CreationDate { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public County County { get; set; }
        public Locality Locality { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<FriendRequest> FriendRequestsUserFrom { get; set; }
        public ICollection<FriendRequest> FriendRequestsUserTo { get; set; }
        public ICollection<Friend> FriendsUser1 { get; set; }
        public ICollection<Friend> FriendsUser2 { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<UserInterest> UserInterest { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
