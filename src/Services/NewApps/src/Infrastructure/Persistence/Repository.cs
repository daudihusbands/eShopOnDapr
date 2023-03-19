using System.Linq.Expressions;
using Ardalis.Specification.EntityFrameworkCore;
using CommonExtensions;
using NewApps.Application.Common.Interfaces;
using NewApps.Domain.Common;

namespace NewApps.Infrastructure.Persistence;

//public abstract class Repository : IRepository
//{


//}

public class Repository<T> : RepositoryBase<T>, IRepository<T>
    where T : BaseEntity//, IAggregateRoot

{
    protected AppDataContext dataContext;
    public IUnitOfWork UnitOfWork => dataContext;


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="connectionString"></param>
    public Repository(AppDataContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }

    protected DbSet<T> DbSet
    {
        get
        {
            if (dataContext == null)
                throw new InvalidOperationException("The database has not been initialized: Cannot get List");

            return dataContext.Set<T>()!;
        }
    }
    public virtual T Add(T entity)
    {
        return dataContext
            .Add(entity)
            .Entity;
    }

    public virtual async Task<T> GetById(int id)
    {
        var item = await GetDefaultIncludes()
            .AsTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        return item!;
    }

    public async virtual Task<T> AddOrUpdateAsync(T item)
    {
        T? existing = GetExisting(item);
        var isNew = existing == null;


        if (isNew)
        {
            item = DbSet.Add(item).Entity;
            await dataContext.SaveChangesAsync();
            return item;
        }
        else
        {
            dataContext.Entry(item).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
        }
        return item;
    }

    public async virtual Task<T> AddAsync(T item)
    {
        T? existing = GetExisting(item);
        var isNew = existing == null;


        if (isNew)
        {
            item = (await DbSet.AddAsync(item)).Entity;
            return item;
        }
        else
        {
            dataContext.Entry(item).State = EntityState.Modified;
        }
        return item;
    }


    protected virtual T? GetExisting(T item)
    {
        if (item.Id == 0)
            return null;

        return DbSet.Find(item.Id)!;
    }

    public virtual T Update(T item)
    {
        dataContext.Entry(item).State = EntityState.Modified;
        return item;
    }
    public virtual Task<T> UpdateAsync(T entity)
    {
        return Task.FromResult(Update(entity));
    }

    public virtual  async Task<IEnumerable<T>> GetAll()
    {
        return await DbSet.ToListAsync();
    }

    public void Remove(T item)
    {
        dataContext.Remove(item);
    }


    public virtual Task<IPagedList<T>> FindPaged(PagedFinder<T> finder)
    {
        var qryResults = GetSearchIncludes();

        qryResults = ProcessSearch(qryResults, finder);

        var pagingInfo = new PagedListPagerDetails(finder.Page, finder.PageSize, 100);

        var numResults = qryResults.Count();

        var result = SortResults(qryResults, finder)
            .Skip(pagingInfo.SkipAmt)
            .Take(pagingInfo.PageSize)
            .ToList();

        var pagedResult = new PagedList<T>(result, pagingInfo.PageIndex, pagingInfo.PageSize, true, numResults);

        return Task.FromResult<IPagedList<T>>(pagedResult);

    }


    protected virtual IQueryable<T> ProcessSearch(IQueryable<T> qryResults, PagedFinder<T> finder)
    {
        if (finder.Where != null)
            qryResults = qryResults.Where(finder.Where);
        else if (!string.IsNullOrEmpty(finder.Term))
        {
            qryResults = qryResults.Where(GetDefaultSearch(finder));

        }
        return qryResults;
    }
    protected virtual IOrderedQueryable<T> SortResults(IQueryable<T> qry, PagedFinder<T> finder)
    {
        var isDesc = string.Equals(finder.SortDir, "desc", StringComparison.OrdinalIgnoreCase);

        return qry.OrderByDynamic(GetDefaultSortField(), SortDirection.Asc);
    }

    protected virtual Expression<Func<T, object>> GetDefaultSortField() => x => x.Id;
    protected virtual Expression<Func<T, bool>> GetDefaultSearch(PagedFinder<T> finder) => (f) => f.Id.ToString().Contains(finder.Term);
    public virtual IQueryable<T> GetDefaultIncludes()
    {
        return DbSet;
    }
    public virtual IQueryable<T> GetSearchIncludes()
    {
        return DbSet;
    }


}

//public class EFRepositoryCoded<T> : EFRepository<T>, IRepositoryCoded<T> where T : EntityCoded
//{
//    public EFRepositoryCoded(AppDataContext dataContext) : base(dataContext)
//    {
//    }

//    public virtual async Task<T> GetByCode(string code)
//    {
//        return await GetDefaultIncludes().SingleOrDefaultAsync(x => x.Code == code);
//    }
//    protected override Expression<Func<T, object>> GetDefaultSortField() => x => x.Code;

//}
