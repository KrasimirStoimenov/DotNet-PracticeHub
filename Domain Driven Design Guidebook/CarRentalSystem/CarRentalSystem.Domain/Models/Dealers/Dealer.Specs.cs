namespace CarRentalSystem.Domain.Models.Dealers;

using CarAds;

using CarRentalSystem.Domain.Exceptions;

using FakeItEasy;

using FluentAssertions;

using Xunit;

public class DealerSpecs
{
    [Fact]
    public void AddCarAd_ShouldSaveCarAd()
    {
        // Arrange
        var dealer = new Dealer("Valid dealer", "+12345678");
        var carAd = A.Dummy<CarAd>();

        // Act
        dealer.AddCarAd(carAd);

        // Assert
        dealer.CarAds.Should().Contain(carAd);
    }

    [Fact]
    public void ValidDealer_ShouldHaveExactProperties()
    {
        // Arrange
        string name = "Valid dealer";
        string phoneNumber = "+12345678";

        // Act
        Dealer dealer = new(name, phoneNumber);

        // Assert
        dealer.Name.Should().Be(name);
        dealer.PhoneNumber.Number.Should().Be(phoneNumber);
    }

    [Fact]
    public void ValidDealer_ShouldNotThrowException()
    {
        // Arrange & Act
        Action act = () => new Dealer("Valid dealer", "+12345678");

        // Assert
        act.Should().NotThrow<InvalidDealerException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData("A")]
    [InlineData("Some really long manufacturer name")]
    public void InvalidName_ShouldThrowException(string name)
    {
        // Arrange & Act
        Action act = () => new Dealer(name, "+12345678");

        // Assert
        act.Should().Throw<InvalidDealerException>();
    }
}
