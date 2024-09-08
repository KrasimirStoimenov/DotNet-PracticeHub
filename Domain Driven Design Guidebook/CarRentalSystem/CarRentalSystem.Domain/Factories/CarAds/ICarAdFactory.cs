namespace CarRentalSystem.Domain.Factories.CarAds;

using CarRentalSystem.Domain.Models.CarAds;

public interface ICarAdFactory : IFactory<CarAd>
{
    ICarAdFactory WithModel(string model);

    ICarAdFactory WithManufacturer(Manufacturer manufacturer);

    ICarAdFactory WithManufacturer(string name);

    ICarAdFactory WithCategory(Category category);

    ICarAdFactory WithCategory(string name, string description);

    ICarAdFactory WithImageUrl(string imageUrl);

    ICarAdFactory WithPricePerDay(decimal pricePerDay);

    ICarAdFactory WithOptions(Options options);

    ICarAdFactory WithOptions(bool hasClimateControl, int numberOfSeats, TransmissionType transmissionType);
}
