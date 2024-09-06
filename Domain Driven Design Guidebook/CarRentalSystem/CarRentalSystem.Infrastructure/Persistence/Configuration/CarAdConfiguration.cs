namespace CarRentalSystem.Infrastructure.Persistence.Configuration;

using CarRentalSystem.Domain.Models.CarAds;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Models.ModelConstants.CarAd;

internal sealed class CarAdConfiguration : IEntityTypeConfiguration<CarAd>
{
    public void Configure(EntityTypeBuilder<CarAd> builder)
    {
        builder
            .HasKey(c => c.Id);

        //Since we do not have two-way navigational properties and foreign key columns, we need to configure the relationships with strings.
        builder
            .HasOne(c => c.Manufacturer)
            .WithMany()
            .HasForeignKey("ManufacturerId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(c => c.Category)
            .WithMany()
            .HasForeignKey("CategoryId")
            .OnDelete(DeleteBehavior.Restrict);

        //For the CarAd.Options ownership, we need to use the OwnsOne method, because Options is a value object and not an entity.
        builder
            .OwnsOne(c => c.Options, o =>
            {
                o.WithOwner();

                o.Property(op => op.NumberOfSeats);
                o.Property(op => op.HasClimateControl);

                //For the Options.TransmissionType ownership, we need to use the OwnsOne method, because TransmissionType is an enumeration and not an entity.
                o.OwnsOne(op => op.TransmissionType, t =>
                {
                    t.WithOwner();

                    t.Property(tr => tr.Value);
                });
            });

        builder
            .Property(c => c.Model)
            .IsRequired()
            .HasMaxLength(MaxModelLength);

        builder
            .Property(c => c.PricePerDay)
            .HasPrecision(18, 4);
    }
}
