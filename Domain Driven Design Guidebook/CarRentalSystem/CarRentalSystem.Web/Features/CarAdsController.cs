namespace CarRentalSystem.Web.Features;

using CarRentalSystem.Application.Features.CarAds.Queries.Search;
using CarRentalSystem.Application.Features.CarAds.Queries.Search.Models;

using Microsoft.AspNetCore.Mvc;

public class CarAdsController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<SearchCarAdsOutputModel>> Get([FromQuery] SearchCarAdsQuery query)
        => await this.Send(query);
}
