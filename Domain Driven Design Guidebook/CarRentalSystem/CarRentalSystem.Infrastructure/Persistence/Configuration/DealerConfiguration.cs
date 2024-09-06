namespace CarRentalSystem.Infrastructure.Persistence.Configuration;

using CarRentalSystem.Domain.Models.Dealers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Models.ModelConstants.Common;
internal sealed class DealerConfiguration : IEntityTypeConfiguration<Dealer>
{
    public void Configure(EntityTypeBuilder<Dealer> builder)
    {
        builder
            .HasKey(d => d.Id);

        //Because the CarAds collection is read-only, we need to explicitly tell EntityFramework Core to use the private field by providing its name.
        builder
            .HasMany(d => d.CarAds)
            .WithOne()
            .Metadata
            .PrincipalToDependent!
            .SetField("carAds");

        builder
            .OwnsOne(d => d.PhoneNumber, p =>
            {
                p.WithOwner();

                p.Property(ph => ph.Number);
            });

        builder
            .Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(MaxNameLength);
    }
}
