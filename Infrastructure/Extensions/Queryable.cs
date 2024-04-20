using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class QueryableExtensions
{
    // =========================================================== //
    // ========================== Where ========================== //
    // =========================================================== //
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, string? value, Expression<Func<T, bool>> predicate)
    {
        return !string.IsNullOrWhiteSpace(value) ? query.Where(predicate) : query;
    }

    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool? value, Expression<Func<T, bool>> predicate)
    {
        return !value.HasValue ? query.Where(predicate) : query;
    }

    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, decimal? value, Expression<Func<T, bool>> predicate)
    {
        return !value.HasValue ? query.Where(predicate) : query;
    }

    // =========================================================== //
    // ======================== ToPageList ======================= //
    // =========================================================== //
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, int? value, Expression<Func<T, bool>> predicate)
    {
        return !value.HasValue ? query.Where(predicate) : query;
    }

    public static async Task<(List<T>, int)> ToSkipTakeAsync<T>(
        this IQueryable<T> source,
        int skip,
        int take,
        CancellationToken cancellationToken = default
    )
        where T : class
    {
        var total = await source.CountAsync(cancellationToken);
        var items = await source.AsNoTracking().Skip(skip).Take(take).ToListAsync(cancellationToken);
        return (items, total);
    }

    public static async Task<(List<T>, int)> ToPageAsync<T>(
        this IQueryable<T> source,
        int page,
        int size,
        CancellationToken cancellationToken = default
    )
        where T : class
    {
        var total = await source.CountAsync(cancellationToken);
        var items = await source.AsNoTracking().Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);
        return (items, total);
    }

    // =========================================================== //
    // ========================= OrderBy ========================= //
    // =========================================================== //
    public const string ASC = "OrderBy";
    public const string DESC = "OrderByDescending";

    public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, string fieldName, string ordering)
    {
        var type = typeof(TSource);
        var property =
            type.GetProperty(fieldName)
            ?? throw new ArgumentException($"Could not find a property named '{fieldName}' on type '{type.FullName}'.");

        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExp = Expression.Lambda(propertyAccess, parameter);
        var resultExp = Expression.Call(
            typeof(Queryable),
            ordering.ToString().ToLower() == "asc" ? "OrderBy" : "OrderByDescending",
            new Type[] { type, property.PropertyType },
            source.Expression,
            Expression.Quote(orderByExp)
        );
        return (IOrderedQueryable<TSource>)source.Provider.CreateQuery<TSource>(resultExp);
    }
}
