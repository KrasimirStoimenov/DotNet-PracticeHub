namespace CarRentalSystem.Application.Features.CarAds.Queries.Search.Models;
public class SearchCarAdsOutputModel
{
    internal SearchCarAdsOutputModel(IEnumerable<CarAdListingModel> carAds, int total)
    {
        CarAds = carAds;
        Total = total;
    }

    public IEnumerable<CarAdListingModel> CarAds { get; }

    public int Total { get; }
}
