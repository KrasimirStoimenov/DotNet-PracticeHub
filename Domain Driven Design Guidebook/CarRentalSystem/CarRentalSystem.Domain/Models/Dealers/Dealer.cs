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

    public string Name { get; }

    public PhoneNumber PhoneNumber { get; }

    public IReadOnlyCollection<CarAd> CarAds
        => this.carAds.ToList().AsReadOnly();

    private void Validate(string name)
        => Guard.ForStringLength<InvalidDealerException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
}
