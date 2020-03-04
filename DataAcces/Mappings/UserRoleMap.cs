using BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");

            builder.HasKey(e => new { e.UserId, e.RoleId });

            builder.HasOne(d => d.Role)
                .WithMany(p => p.UserRole)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_Role");

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserRole)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_User");
        }
    }
}
