namespace CarRentalSystem.Web.Features;

using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Models.CarAds;
using CarRentalSystem.Domain.Models.Dealers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CarAdsController(IRepository<CarAd> carAdRepository) : ControllerBase
{
    private static readonly Dealer dealer = new("Dealer", "+12345678");

    [HttpGet]
    public IEnumerable<CarAd> Get()
        => carAdRepository
            .GetAll()
            .Where(c => c.IsAvailable);
}
