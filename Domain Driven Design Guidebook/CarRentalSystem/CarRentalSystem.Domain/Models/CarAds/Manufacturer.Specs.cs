namespace CarRentalSystem.Domain.Models.CarAds;

using CarRentalSystem.Domain.Exceptions;

using FluentAssertions;

using Xunit;

public class ManufacturerSpecs
{
    [Fact]
    public void ValidManufacturer_ShouldHaveExactProperties()
    {
        // Arrange
        string name = "Valid name";

        // Act
        Manufacturer manufacturer = new(name);

        // Assert
        manufacturer.Name.Should().Be(name);
    }

    [Fact]
    public void ValidManufacturer_ShouldNotThrowException()
    {
        // Arrange & Act
        Action act = () => new Manufacturer("Valid name");

        // Assert
        act.Should().NotThrow<InvalidCarAdException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData("A")]
    [InlineData("Some really long manufacturer name")]
    public void InvalidName_ShouldThrowException(string name)
    {
        // Arrange & Act
        Action act = () => new Manufacturer(name);

        // Assert
        act.Should().Throw<InvalidCarAdException>();
    }
}
