﻿namespace CarRentalSystem.Domain.Factories.CarAds;

using Exceptions;

using FluentAssertions;

using Models.CarAds;

using Xunit;

public class CarAdFactorySpecs
{
    [Fact]
    public void Build_ShouldThrowExceptionIfManufacturerIsNotSet()
    {
        // Assert
        var carAdFactory = new CarAdFactory();

        // Act
        Action act = () => carAdFactory
            .WithCategory("TestCategory", "TestDescription")
            .WithOptions(true, 2, TransmissionType.Automatic)
            .Build();

        // Assert
        act.Should().Throw<InvalidCarAdException>();
    }

    [Fact]
    public void Build_ShouldThrowExceptionIfCategoryIsNotSet()
    {
        // Assert
        var carAdFactory = new CarAdFactory();

        // Act
        Action act = () => carAdFactory
            .WithManufacturer("TestManufacturer")
            .WithOptions(true, 2, TransmissionType.Automatic)
            .Build();

        // Assert
        act.Should().Throw<InvalidCarAdException>();
    }

    [Fact]
    public void Build_ShouldThrowExceptionIfOptionsAreNotSet()
    {
        // Assert
        var carAdFactory = new CarAdFactory();

        // Act
        Action act = () => carAdFactory
            .WithManufacturer("TestManufacturer")
            .WithCategory("TestCategory", "TestDescription")
            .Build();

        // Assert
        act.Should().Throw<InvalidCarAdException>();
    }

    [Fact]
    public void Build_ShouldCreateCarAdIfEveryPropertyIsSet()
    {
        // Assert
        var carAdFactory = new CarAdFactory();

        // Act
        var carAd = carAdFactory
            .WithManufacturer("TestManufacturer")
            .WithCategory("TestCategory", "TestCategoryDescription")
            .WithOptions(true, 2, TransmissionType.Automatic)
            .WithImageUrl("http://test.image.url")
            .WithModel("TestModel")
            .WithPricePerDay(10)
            .Build();

        // Assert
        carAd.Should().NotBeNull();
    }
}
