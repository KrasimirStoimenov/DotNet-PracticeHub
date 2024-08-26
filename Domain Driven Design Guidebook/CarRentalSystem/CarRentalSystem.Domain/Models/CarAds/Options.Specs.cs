namespace CarRentalSystem.Domain.Models.CarAds;
using CarRentalSystem.Domain.Exceptions;

using FluentAssertions;

using Xunit;

public class OptionsSpecs
{
    [Fact]
    public void ValidOptions_ShouldHaveExactProperties()
    {
        // Arrange
        bool hasClimateControl = true;
        int numberOfSeats = 4;
        TransmissionType transmissionType = TransmissionType.Automatic;

        // Act
        Options options = new(hasClimateControl, numberOfSeats, transmissionType);

        // Assert
        options.HasClimateControl.Should().Be(hasClimateControl);
        options.NumberOfSeats.Should().Be(numberOfSeats);
        options.TransmissionType.Should().Be(transmissionType);
    }

    [Fact]
    public void ValidOptions_ShouldNotThrowException()
    {
        // Arrange & Act
        Action act = () => new Options(true, 4, TransmissionType.Manual);

        // Assert
        act.Should().NotThrow<InvalidOptionsException>();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(51)]
    public void InvalidNumberOfSeats_ShouldThrowException(int numberOfSeats)
    {
        // Arrange & Act
        Action act = () => new Options(false, numberOfSeats, TransmissionType.Manual);

        // Assert
        act.Should().Throw<InvalidOptionsException>();
    }
}
