namespace CarRentalSystem.Domain.Models.Dealers;

using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.CarAds;

using static ModelConstants.Common;

public class Dealer : Entity<int>, IAggregateRoot
{
    private readonly HashSet<CarAd> carAds;

    public Dealer(string name, string phoneNumber)
    {
        this.Validate(name);

        this.Name = name;
        this.PhoneNumber = phoneNumber;

        this.carAds = [];
    }

    private Dealer(string name)
    {
        this.Name = name;
        this.PhoneNumber = default!;

        this.carAds = [];
    }

    public string Name { get; init; }

    public PhoneNumber PhoneNumber { get; init; }

    public IReadOnlyCollection<CarAd> CarAds
        => this.carAds.ToList().AsReadOnly();

    public void AddCarAd(CarAd carAd)
        => this.carAds.Add(carAd);

    private void Validate(string name)
        => Guard.ForStringLength<InvalidDealerException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}
