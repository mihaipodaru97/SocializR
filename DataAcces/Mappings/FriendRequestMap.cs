using BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces.Mappings
{
    public class FriendRequestMap : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.ToTable("FriendRequests");

            builder.HasKey(e => new { e.UserFromId, e.UserToId });

            builder.HasOne(d => d.UserFrom)
                .WithMany(p => p.FriendRequestsUserFrom)
                .HasForeignKey(d => d.UserFromId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FriendRequest_User");

            builder.HasOne(d => d.UserTo)
                .WithMany(p => p.FriendRequestsUserTo)
                .HasForeignKey(d => d.UserToId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FriendRequest_User1");
        }
    }
}
