using BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces.Mappings
{
    public class RolePermissionMap : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolePermission");

            builder.HasKey(e => new { e.RoleId, e.PermissionId });

            builder.HasOne(d => d.Permission)
                .WithMany(p => p.RolePermission)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_Permission");

            builder.HasOne(d => d.Role)
                .WithMany(p => p.RolePermission)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_Role");
        }
    }
}
