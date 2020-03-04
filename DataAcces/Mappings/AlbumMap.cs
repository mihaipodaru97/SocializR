using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BusinessEntities.Entities;

namespace DataAcces.Mappings
{
    public class AlbumMap : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Albums)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Album_User");
        }
    }
}
