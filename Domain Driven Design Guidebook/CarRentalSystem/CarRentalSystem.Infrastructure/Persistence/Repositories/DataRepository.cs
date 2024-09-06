namespace CarRentalSystem.Infrastructure.Persistence.Repositories;

using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Common;

internal sealed class DataRepository<TEntity>(CarRentalDbContext dbContext) : IRepository<TEntity>
    where TEntity : class, IAggregateRoot
{
    public IQueryable<TEntity> GetAll()
        => dbContext.Set<TEntity>();

    public Task<int> SaveChanges(CancellationToken cancellationToken)
        => dbContext.SaveChangesAsync(cancellationToken);
}
