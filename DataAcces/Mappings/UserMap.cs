using BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasIndex(t => t.Email).IsUnique();

            builder.Property(e => e.Birthday).HasColumnType("date");

            builder.Property(e => e.CreationDate).HasColumnType("date");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.County)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.CountyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_City");

            builder.HasOne(d => d.Locality)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.LocalityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Locality");
        }
    }
}
