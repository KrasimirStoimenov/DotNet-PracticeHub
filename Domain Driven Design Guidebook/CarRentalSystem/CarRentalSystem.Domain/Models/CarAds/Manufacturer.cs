﻿namespace CarRentalSystem.Domain.Models.CarAds;

using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;

using static ModelConstants.Common;

public class Manufacturer : Entity<int>
{
    internal Manufacturer(string name)
    {
        this.Validate(name);

        this.Name = name;
    }

    public string Name { get; init; }

    private void Validate(string name)
        => Guard.ForStringLength<InvalidCarAdException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}
