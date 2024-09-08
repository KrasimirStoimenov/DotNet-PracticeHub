namespace CarRentalSystem.Domain.Factories.Dealers;

using CarRentalSystem.Domain.Models.Dealers;

internal class DealerFactory : IDealerFactory
{
    private string dealerName = default!;
    private string phoneNumber = default!;

    public IDealerFactory WithName(string name)
    {
        this.dealerName = name;
        return this;
    }

    public IDealerFactory WithPhoneNumber(string phoneNumber)
    {
        this.phoneNumber = phoneNumber;
        return this;
    }

    public Dealer Build()
        => new(this.dealerName, this.phoneNumber);

    public Dealer Build(string dealerName, string phoneNumber)
        => this
            .WithName(dealerName)
            .WithPhoneNumber(phoneNumber)
            .Build();
}
