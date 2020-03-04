using BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces.Mappings
{
    class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
