namespace CarRentalSystem.Domain.Factories.Dealers;

using FluentAssertions;

using Xunit;

public class DealerFactorySpecs
{
    [Fact]
    public void Build_ShouldCreateDealerWhenFluentSyntaxIsUsed()
    {
        // Arrange
        var dealerFactory = new DealerFactory();

        // Act
        var dealer = dealerFactory
            .WithName("TestDealer")
            .WithPhoneNumber("+12345678")
            .Build();

        // Assert
        dealer.Should().NotBeNull();
    }

    [Fact]
    public void Build_ShouldCreateDealerWhenInlineParametersArePassed()
    {
        // Arrange
        var dealerFactory = new DealerFactory();

        // Act
        var dealer = dealerFactory.Build("Valid dealer", "+12345678");

        // Assert
        dealer.Should().NotBeNull();
    }
}
