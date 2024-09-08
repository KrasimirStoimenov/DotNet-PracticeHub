namespace CarRentalSystem.Application.Features.CarAds.Queries.Search;

using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Application.Features.CarAds.Queries.Search.Models;

using MediatR;

public class SearchCarAdsQuery : IRequest<Result<SearchCarAdsOutputModel>>
{
    public string? Manufacturer { get; set; }

    public class SearchCarAdsQueryHandler(ICarAdRepository carAdRepository) : IRequestHandler<SearchCarAdsQuery, Result<SearchCarAdsOutputModel>>
    {
        public async Task<Result<SearchCarAdsOutputModel>> Handle(SearchCarAdsQuery request, CancellationToken cancellationToken)
        {
            var carAdListings = await carAdRepository.GetCarAdListings(request.Manufacturer, cancellationToken);

            var totalCarAds = await carAdRepository.Total(cancellationToken);

            return new SearchCarAdsOutputModel(carAdListings, totalCarAds);
        }
    }
}
