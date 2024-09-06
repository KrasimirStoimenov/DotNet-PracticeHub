namespace CarRentalSystem.Infrastructure.Persistence.Configuration;

using CarRentalSystem.Infrastructure.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasOne(u => u.Dealer)
            .WithOne()
            .HasForeignKey<User>("DealerId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
