﻿namespace CarRentalSystem.Application.Features.CarAds.Queries.Search.Models;
public class CarAdListingModel
{
    public CarAdListingModel(
        int id,
        string manufacturer,
        string model,
        string imageUrl,
        string category,
        decimal pricePerDay)
    {
        Id = id;
        Manufacturer = manufacturer;
        Model = model;
        ImageUrl = imageUrl;
        Category = category;
        PricePerDay = pricePerDay;
    }

    public int Id { get; }

    public string Manufacturer { get; }

    public string Model { get; }

    public string ImageUrl { get; }

    public string Category { get; }

    public decimal PricePerDay { get; }
}
