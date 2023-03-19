namespace NewApps.Application.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> SaveDomainEntitiesAsync(CancellationToken cancellationToken = default);
}
