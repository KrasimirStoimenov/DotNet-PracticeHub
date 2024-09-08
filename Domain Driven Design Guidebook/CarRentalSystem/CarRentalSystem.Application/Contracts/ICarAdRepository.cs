namespace CarRentalSystem.Application.Contracts;

using CarRentalSystem.Application.Features.CarAds.Queries.Search.Models;

using Domain.Models.CarAds;

public interface ICarAdRepository : IRepository<CarAd>
{
    Task<IEnumerable<CarAdListingModel>> GetCarAdListings(
        string? manufacturer = default,
        CancellationToken cancellationToken = default);

    Task<int> Total(CancellationToken cancellationToken = default);
}
