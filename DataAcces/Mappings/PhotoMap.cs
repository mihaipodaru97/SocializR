using BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces.Mappings
{
    public class PhotoMap : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photos");

            builder.Property(e => e.Description).HasMaxLength(150);

            builder.HasOne(d => d.Album)
                .WithMany(p => p.Photos)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK_Photo_Album");
        }
    }
}
