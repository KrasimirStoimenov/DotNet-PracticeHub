namespace CarRentalSystem.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

internal class CarRentalDbInitializer(CarRentalDbContext db) : IInitializer
{
    public void Initialize()
        => db.Database.Migrate();
}
