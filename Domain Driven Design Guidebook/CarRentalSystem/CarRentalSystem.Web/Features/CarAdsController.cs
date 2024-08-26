namespace CarRentalSystem.Web.Features;

using CarRentalSystem.Domain.Models.CarAds;
using CarRentalSystem.Domain.Models.Dealers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CarAdsController : ControllerBase
{
    private static readonly Dealer dealer = new("Dealer", "+12345678");

    [HttpGet]
    public IEnumerable<CarAd> Get()
        => dealer
            .CarAds
            .Where(x => x.IsAvailable);
}
