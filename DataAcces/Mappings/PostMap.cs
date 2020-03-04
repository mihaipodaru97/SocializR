using BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.Property(e => e.Body).IsRequired();

            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.NumberOfLikes).HasDefaultValueSql("((0))");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_User");
        }
    }
}
