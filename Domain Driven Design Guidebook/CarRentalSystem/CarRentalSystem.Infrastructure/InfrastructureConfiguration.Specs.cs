﻿namespace CarRentalSystem.Infrastructure;

using CarRentalSystem.Application.Contracts;

using FluentAssertions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Persistence;

using Xunit;

public class InfrastructureConfigurationSpecs
{
    [Fact]
    public void AddRepositoriesShouldRegisterRepositories()
    {
        // Arrange
        var serviceCollection = new ServiceCollection()
            .AddDbContext<CarRentalDbContext>(opts => opts
                .UseInMemoryDatabase(Guid.NewGuid().ToString()));

        // Act
        var services = serviceCollection
            .AddRepositories()
            .BuildServiceProvider();

        // Assert
        services
            .GetService<ICarAdRepository>()
            .Should()
            .NotBeNull();
    }
}
