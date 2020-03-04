using BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcces.Mappings
{
    public class UserInterestMap : IEntityTypeConfiguration<UserInterest>
    {
        public void Configure(EntityTypeBuilder<UserInterest> builder)
        {
            builder.ToTable("UserInterest");

            builder.HasKey(e => new { e.UserId, e.InterestId });

            builder.HasOne(d => d.Interest)
                .WithMany(p => p.UserInterest)
                .HasForeignKey(d => d.InterestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserInterest_Interest");

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserInterest)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserInterest_User");
        }
    }
}
