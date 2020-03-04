using DataAcces.Mappings;
using Microsoft.EntityFrameworkCore;
using BusinessEntities.Entities;

namespace DataAcces.Base
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInterest> UserInterest { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlbumMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new CountyMap());
            modelBuilder.ApplyConfiguration(new FriendRequestMap());
            modelBuilder.ApplyConfiguration(new FriendMap());
            modelBuilder.ApplyConfiguration(new InterestMap());
            modelBuilder.ApplyConfiguration(new LikeMap());
            modelBuilder.ApplyConfiguration(new LocalityMap());
            modelBuilder.ApplyConfiguration(new PermissionMap());
            modelBuilder.ApplyConfiguration(new PhotoMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new RolePermissionMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserInterestMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}