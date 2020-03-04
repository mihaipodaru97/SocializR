using BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces.Mappings
{
    public class InterestMap : IEntityTypeConfiguration<Interest>
    {
        public void Configure(EntityTypeBuilder<Interest> builder)
        {
            builder.ToTable("Interests");

            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasIndex(e => e.Name)
                    .IsUnique();
        }
    }
}
