﻿namespace CarRentalSystem.Domain.Models.CarAds;

using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;

using static ModelConstants.Category;
using static ModelConstants.Common;

public class Category : Entity<int>
{
    internal Category(string name, string description)
    {
        this.Validate(name, description);

        this.Name = name;
        this.Description = description;
    }

    public string Name { get; init; }

    public string Description { get; init; }

    private void Validate(string name, string description)
    {
        Guard.ForStringLength<InvalidCarAdException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));

        Guard.ForStringLength<InvalidCarAdException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));
    }
}
