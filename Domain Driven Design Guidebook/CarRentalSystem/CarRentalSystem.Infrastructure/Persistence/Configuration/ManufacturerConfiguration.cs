﻿namespace CarRentalSystem.Infrastructure.Persistence.Configuration;

using CarRentalSystem.Domain.Models.CarAds;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Models.ModelConstants.Common;

internal sealed class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder
            .HasKey(m => m.Id);

        builder
            .Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(MaxNameLength);
    }
}
