using BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
