namespace CarRentalSystem.Domain.Models.CarAds;

using CarRentalSystem.Domain.Exceptions;

using FluentAssertions;

using Xunit;

public class CategorySpecs
{
    [Fact]
    public void ValidCategory_ShouldHaveExactProperties()
    {
        // Arrange
        string name = "Valid name";
        string description = "Valid description text";

        // Act
        Category category = new(name, description);

        // Assert
        category.Name.Should().Be(name);
        category.Description.Should().Be(description);
    }

    [Fact]
    public void ValidCategory_ShouldNotThrowException()
    {
        // Arrange & Act
        Action act = () => new Category("Valid name", "Valid description text");

        // Assert
        act.Should().NotThrow<InvalidCarAdException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData("A")]
    [InlineData("Some really long category name")]
    public void InvalidName_ShouldThrowException(string name)
    {
        // Arrange & Act
        Action act = () => new Category(name, "Valid description text");

        // Assert
        act.Should().Throw<InvalidCarAdException>();
    }

    [Theory]
    [InlineData("")]
    [InlineData("Desc")]
    public void InvalidDescription_ShouldThrowException(string description)
    {
        // Arrange & Act
        Action act = () => new Category("Valid name", description);

        // Assert
        act.Should().Throw<InvalidCarAdException>();
    }
}
