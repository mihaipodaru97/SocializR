using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BusinessEntities.Entities;

namespace DataAcces.Mappings
{
    public class CountyMap : IEntityTypeConfiguration<County>
    {
        public void Configure(EntityTypeBuilder<County> builder)
        {
            builder.ToTable("Counties");

            builder.HasIndex(t => t.Name).IsUnique();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}