using BusinessEntities.Entities;

namespace DataAcces.Base
{
    public class UnitOfWork
    {
        private Context context;
        public UnitOfWork(Context context)
        {
            this.context = context;
        }


        private IRepository<Album> albums;
        public IRepository<Album> Albums => (albums ?? (albums = new Repository<Album>(context)));

        private IRepository<UserInterest> userInterest;
        public IRepository<UserInterest> UserInterests => (userInterest ?? (userInterest = new Repository<UserInterest>(context)));

        private IRepository<Comment> comments;
        public IRepository<Comment> Comments => (comments ?? (comments = new Repository<Comment>(context)));

        private IRepository<County> counties;
        public IRepository<County> Counties => (counties ?? (counties = new Repository<County>(context)));

        private IRepository<Friend> friends;
        public IRepository<Friend> Friends => (friends ?? (friends = new Repository<Friend>(context)));

        private IRepository<User> users;
        public IRepository<User> Users => (users ?? (users = new Repository<User>(context)));

        private IRepository<Locality> localities;
        public IRepository<Locality> Localities => (localities ?? (localities = new Repository<Locality>(context)));

        private IRepository<Interest> interests;
        public IRepository<Interest> Interests => (interests ?? (interests = new Repository<Interest>(context)));

        private IRepository<Photo> photos;
        public IRepository<Photo> Photos=> (photos ?? (photos = new Repository<Photo>(context)));

        private IRepository<Like> likes;
        public IRepository<Like> Likes => (likes ?? (likes = new Repository<Like>(context)));

        private IRepository<Post> posts;
        public IRepository<Post> Posts => (posts ?? (posts = new Repository<Post>(context)));

        private IRepository<FriendRequest> friendRequests;
        public IRepository<FriendRequest> FriendsRequests => (friendRequests ?? (friendRequests = new Repository<FriendRequest>(context)));

        private IRepository<UserRole> userRole;
        public IRepository<UserRole> UserRole => (userRole ?? (userRole = new Repository<UserRole>(context)));


        public virtual bool Save()
        {
            try
            {
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
