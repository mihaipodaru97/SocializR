using BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces.Mappings
{
    public class LocalityMap : IEntityTypeConfiguration<Locality>
    {
        public void Configure(EntityTypeBuilder<Locality> builder)
        {
            builder.ToTable("Localities");

            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasIndex(t => t.Name)
                    .IsUnique();

            builder.HasOne(d => d.County)
                .WithMany(p => p.Localities)
                .HasForeignKey(d => d.CountyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Locality_City");
        }
    }
}
