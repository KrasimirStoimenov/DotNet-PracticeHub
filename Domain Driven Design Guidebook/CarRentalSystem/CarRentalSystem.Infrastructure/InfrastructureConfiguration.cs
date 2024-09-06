﻿namespace CarRentalSystem.Infrastructure;

using CarRentalSystem.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddDbContext<CarRentalDbContext>(opts => opts
                .UseSqlServer(
                    configuration.GetConnectionString("CarRentalSystemDb"),
                    b => b.MigrationsAssembly(typeof(CarRentalDbContext).Assembly.FullName)));
}
