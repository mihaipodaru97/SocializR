using BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces.Mappings
{
    public class FriendMap : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable("Friends");

            builder.HasKey(e => new { e.User1Id, e.User2Id });

            builder.Property(e => e.Date).HasColumnType("date");

            builder.HasOne(d => d.User1)
                .WithMany(p => p.FriendsUser1)
                .HasForeignKey(d => d.User1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friends_User");

            builder.HasOne(d => d.User2)
                .WithMany(p => p.FriendsUser2)
                .HasForeignKey(d => d.User2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friends_User1");
        }
    }
}
