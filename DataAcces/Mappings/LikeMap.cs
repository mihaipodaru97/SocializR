using BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces.Mappings
{
    public class LikeMap : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Likes");

            builder.HasKey(e => new { e.UserId, e.PostId });

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Like_Post");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Likes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Like_User");
        }
    }
}
