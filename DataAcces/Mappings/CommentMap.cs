using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BusinessEntities.Entities;

namespace DataAcces.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.Property(e => e.Body)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Post");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_User");
        }
    }
}
