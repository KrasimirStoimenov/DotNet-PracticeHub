namespace CarRentalSystem.Infrastructure.Persistence.Repositories;

using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Common;

internal class DataRepository<TEntity>(CarRentalDbContext dbContext) : IRepository<TEntity>
    where TEntity : class, IAggregateRoot
{
    protected IQueryable<TEntity> GetAll()
        => dbContext.Set<TEntity>();
}
