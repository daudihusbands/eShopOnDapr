using Ardalis.Specification;
using CommonExtensions;
using NewApps.Domain.Common;

namespace NewApps.Application.Common.Interfaces;

public interface IRepository
{
}
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class//, IAggregateRoot
{
}
// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : BaseEntity//, IAggregateRoot
{
    //}
    //public interface IRepository<T> : IRepository where T : IAggregateRoot
    //{
    IUnitOfWork UnitOfWork { get; }
    Task<IEnumerable<T>> GetAll();
    T Add(T entity);
    Task<T> AddAsync(T entity);
    Task<T> GetById(int id);
    T Update(T application);
    Task<T> UpdateAsync(T entity);
    Task<T> AddOrUpdateAsync(T entity);
    void Remove(T item);
    Task<IPagedList<T>> FindPaged(PagedFinder<T> finder);

    IQueryable<T> GetDefaultIncludes();
    IQueryable<T> GetSearchIncludes();
}
//public interface IRepositoryCoded<T> : IRepository<T>
//where T : EntityCoded, IAggregateRoot
//{
//    Task<T> GetByCode(string code);
//}
