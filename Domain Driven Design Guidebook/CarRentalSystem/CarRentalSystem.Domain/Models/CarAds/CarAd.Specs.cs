namespace CarRentalSystem.Domain.Models.CarAds;

using CarRentalSystem.Domain.Exceptions;

using FakeItEasy;

using FluentAssertions;

using Xunit;

public class CarAdSpecs
{
    [Fact]
    public void ValidCarAd_ShouldNotThrowException()
    {
        // Arrange & Act
        Action act = () => A.Dummy<CarAd>();

        // Assert
        act.Should().NotThrow<InvalidCarAdException>();
    }

    [Fact]
    public void ChangeAvailability_ShouldMutateIsAvailable()
    {
        // Arrange
        var carAd = A.Dummy<CarAd>();

        // Act
        carAd.ChangeAvailability();

        // Assert
        carAd.IsAvailable.Should().BeFalse();
    }
}
