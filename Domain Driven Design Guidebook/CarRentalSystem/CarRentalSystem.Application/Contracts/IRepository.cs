namespace CarRentalSystem.Application.Contracts;

using CarRentalSystem.Domain.Common;

public interface IRepository<out TEntity>
    where TEntity : IAggregateRoot
{
    IQueryable<TEntity> GetAll();

    Task<int> SaveChanges(CancellationToken cancellationToken);
}
