namespace HusJel.Applications.API.Common.Interfaces.Persistence;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> SaveDomainEntitiesAsync(CancellationToken cancellationToken = default);
}
