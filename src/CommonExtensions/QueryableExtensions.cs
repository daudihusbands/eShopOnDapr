using System.Linq.Expressions;
using CommonExtensions;

namespace CommonExtensions;

public static class QueryableExtensions
{
    public static IOrderedQueryable<T> OrderByDynamic<T, TKey>(this IQueryable<T> source, Expression<Func<T, TKey>> keySelector, SortDirection sortDirection)
    {
        if (sortDirection == SortDirection.Asc)
            return source.OrderBy(keySelector);
        else
            return source.OrderByDescending(keySelector);
    }

    public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, IEnumerable<SortInfo<T>> sortInfos)
    {
        var expression = source.Expression;
        var count = 0;
        foreach (var item in sortInfos)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var selector = Expression.PropertyOrField(parameter, item.FieldName);
            var method = item.SortDirection == SortDirection.Desc ?
                count == 0 ? "OrderByDescending" : "ThenByDescending" :
                count == 0 ? "OrderBy" : "ThenBy";
            expression = Expression.Call(typeof(Queryable), method,
                new Type[] { source.ElementType, selector.Type },
                expression, Expression.Quote(Expression.Lambda(selector, parameter)));
            count++;
        }
        return count > 0 ? source.Provider.CreateQuery<T>(expression) : source;
    }
}
