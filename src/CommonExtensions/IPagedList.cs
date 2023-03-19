using System.Linq.Expressions;

namespace CommonExtensions
{
    public interface IPagedList<T> : IList<T>
    {
        int PageCount { get; }
        int TotalItemCount { get; }
        int PageIndex { get; }
        int PageNumber { get; }
        int PageSize { get; }

        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        bool IsFirstPage { get; }
        bool IsLastPage { get; }

        bool IsSinglePageResults { get; set; }
    }

    public class PagedFinder<T>
    {
        public string StartsWith { get; set; }
        public string QueryString { get; set; }
        public int? NumRecordsPerPage { get; set; }
        public int? StartPageNumber { get; set; }
        public int? MaxRecords { get; set; }
        public string SearchField { get; set; }
        public string FieldAlias { get; set; }
        public IEnumerable<SortInfo<T>> SortInfos { get; set; }
        public Expression<Func<T, bool>> Where { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string Term { get; set; }
        public string SortBy { get; set; }
        public string SortDir { get; set; }

        public int? NoCount { get; set; }


    }
    public class SortInfo<T>
    {
        public string FieldName { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public SortDirection SortDirection { get; set; }

    }
    public enum SortDirection { Asc, Desc }

    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IEnumerable<T> source, int index, int pageSize)
            : this(source, index, pageSize, null)
        {
        }

        public PagedList(IEnumerable<T> source, int index, int pageSize, int? totalCount)
        {
            Initialize(source.AsQueryable(), index, pageSize, totalCount);
        }
        public PagedList(IEnumerable<T> source, int index, int pageSize, bool isSinglePageResults, int? totalCount)
        {
            IsSinglePageResults = isSinglePageResults;
            Initialize(source.AsQueryable(), index, pageSize, totalCount);
        }
        public PagedList(IQueryable<T> source, int index, int pageSize)
            : this(source, index, pageSize, null)
        {
        }

        public PagedList(IQueryable<T> source, int index, int pageSize, int? totalCount)
        {
            Initialize(source, index, pageSize, totalCount);
        }

        public PagedFinder<T> InputParameters { get; set; }

        #region IPagedList Members

        public int PageCount { get; protected set; }
        public int TotalItemCount { get; protected set; }
        public int PageIndex { get; protected set; }
        public int PageNumber { get { return PageIndex + 1; } }
        public int PageSize { get; protected set; }
        public bool HasPreviousPage { get; protected set; }
        public bool HasNextPage { get; protected set; }
        public bool IsFirstPage { get; protected set; }
        public bool IsLastPage { get; protected set; }

        #endregion

        protected void Initialize(IQueryable<T> source, int index, int pageSize, int? totalCount)
        {
            //### argument checking
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("PageIndex cannot be below 0.");
            }
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("PageSize cannot be less than 1.");
            }

            //### set source to blank list if source is null to prevent exceptions
            if (source == null)
            {
                source = new List<T>().AsQueryable();
            }

            //### set properties

            if (!totalCount.HasValue)
            {
                TotalItemCount = source.Count();
            }
            else
                TotalItemCount = totalCount.Value;

            PageSize = pageSize;
            PageIndex = index;
            if (TotalItemCount > 0)
            {
                PageCount = (int)Math.Ceiling(TotalItemCount / (double)PageSize);
            }
            else
            {
                PageCount = 0;
            }
            HasPreviousPage = PageIndex > 0;
            HasNextPage = PageIndex < PageCount - 1;
            IsFirstPage = PageIndex <= 0;
            IsLastPage = PageIndex >= PageCount - 1;

            //### add items to internal list
            if (IsSinglePageResults)
                AddRange(source);

            else if (TotalItemCount > 0)
            {
                AddRange(source.Skip(index * pageSize).Take(pageSize).ToList());
            }

        }


        public bool IsSinglePageResults { get; set; }
    }


    public class PagedListPagerDetails
    {
        readonly int page;
        readonly int pageSize;
        readonly int maxResults;
        public PagedListPagerDetails(int? page, int? pageSize, int? maxResults = null)
        {
            this.page = page.GetValueOrDefault();// page.HasValue ? page.Value : 0;
            this.maxResults = maxResults != null ? maxResults.Value : int.MaxValue;
            this.pageSize = pageSize != null && pageSize.HasValue && pageSize.Value <= this.maxResults ? pageSize.Value : this.maxResults;
        }
        public int PageIndex
        {
            get
            {
                return page;
            }
        }
        public int PageSize { get { return pageSize; } }
        public int SkipAmt
        {
            get
            {
                return PageIndex * pageSize;
            }
        }


    }

    public class PagedSearchResult<T>
    {
        public PagedSearchResult()
        {

        }
        public PagedSearchResult(IPagedList<T> list)
        {
            Page = list.PageIndex;

            Items = list.ToList();
            PageSize = list.PageSize;
            Total = list.TotalItemCount;
            PageCount = list.PageCount;
        }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public IList<T> Items { get; set; }
        public int Total { get; set; }
        public int PageCount { get; set; }

    }
}
