namespace CarRentalSystem.Infrastructure.Persistence.Repositories;

using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Application.Features.CarAds.Queries.Search.Models;

using Domain.Models.CarAds;

using Microsoft.EntityFrameworkCore;

internal class CarAdRepository : DataRepository<CarAd>, ICarAdRepository
{
    public CarAdRepository(CarRentalDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<IEnumerable<CarAdListingModel>> GetCarAdListings(
        string? manufacturer,
        CancellationToken cancellationToken)
    {
        var query = this.AllAvailable();

        if (!string.IsNullOrWhiteSpace(manufacturer))
        {
            query = query
                .Where(car => EF
                    .Functions
                    .Like(car.Manufacturer.Name, $"%{manufacturer}%"));
        }

        return await query
            .Select(car => new CarAdListingModel(
                car.Id,
                car.Manufacturer.Name,
                car.Model,
                car.ImageUrl,
                car.Category.Name,
                car.PricePerDay))
            .ToListAsync(cancellationToken);
    }

    public async Task<int> Total(CancellationToken cancellationToken)
        => await this
            .AllAvailable()
            .CountAsync(cancellationToken);

    private IQueryable<CarAd> AllAvailable()
        => this
            .GetAll()
            .Where(car => car.IsAvailable);
}
