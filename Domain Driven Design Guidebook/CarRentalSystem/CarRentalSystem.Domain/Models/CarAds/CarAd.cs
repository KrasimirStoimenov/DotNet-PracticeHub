namespace CarRentalSystem.Domain.Models.CarAds;

using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;

using static ModelConstants.CarAd;
using static ModelConstants.Common;

public class CarAd : Entity<int>, IAggregateRoot
{
    internal CarAd(
        string model,
        Manufacturer manufacturer,
        Category category,
        string imageUrl,
        decimal pricePerDay,
        Options options,
        bool isAvailable)
    {
        this.Validate(model, imageUrl, pricePerDay);

        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Category = category;
        this.ImageUrl = imageUrl;
        this.PricePerDay = pricePerDay;
        this.Options = options;
        this.IsAvailable = isAvailable;
    }

    /*  Entity Framework Core wants constructors that bind non-navigational properties,
        but according to the Domain-Driven Design principles, entities cannot be created with an invalid state.
        The solution is to add additional private constructors to our domain model classes for Entity Framework Core to use.*/

    private CarAd(
        string model,
        string imageUrl,
        decimal pricePerDay,
        bool isAvailable)
    {
        this.Model = model;
        this.ImageUrl = imageUrl;
        this.PricePerDay = pricePerDay;
        this.IsAvailable = isAvailable;

        this.Manufacturer = default!;
        this.Category = default!;
        this.Options = default!;
    }

    public string Model { get; init; }

    public Manufacturer Manufacturer { get; init; }

    public Category Category { get; init; }

    public string ImageUrl { get; init; }

    public decimal PricePerDay { get; init; }

    public Options Options { get; init; }

    public bool IsAvailable { get; private set; }

    public void ChangeAvailability()
        => this.IsAvailable = !this.IsAvailable;

    private void Validate(string model, string imageUrl, decimal pricePerDay)
    {
        Guard.ForStringLength<InvalidCarAdException>(
            model,
            MinModelLength,
            MaxModelLength,
            nameof(this.Model));

        Guard.ForValidUrl<InvalidCarAdException>(
            imageUrl,
            nameof(this.ImageUrl));

        Guard.AgainstOutOfRange<InvalidCarAdException>(
            pricePerDay,
            Zero,
            decimal.MaxValue,
            nameof(this.PricePerDay));
    }
}
