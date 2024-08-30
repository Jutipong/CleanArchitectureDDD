using System.Linq.Expressions;

namespace Infrastructure.Extensions;

public static class QueryableExtensions
{
    // =========================================================== //
    // ======================== ToPageList ======================= //
    // =========================================================== //

    public class PageListResponse<T>
    {
        public List<T> Items { get; set; } = [];
        public int Total { get; set; } = 0;
    }

    public static async Task<PageListResponse<T>> ToSkipTakeAsync<T>(
        this IQueryable<T> source,
        int skip,
        int take,
        CancellationToken cancellationToken = default
    )
        where T : class
    {
        var total = await source.AsNoTracking().CountAsync(cancellationToken);
        var items = await source.AsNoTracking().Skip(skip).Take(take).ToListAsync(cancellationToken);
        return new PageListResponse<T> { Items = items, Total = total };
    }

    public static async Task<PageListResponse<T>> ToPageAsync<T>(
        this IQueryable<T> source,
        int page,
        int size,
        CancellationToken cancellationToken = default
    )
        where T : class
    {
        var total = await source.AsNoTracking().CountAsync(cancellationToken);
        var items = await source.AsNoTracking().Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);
        return new PageListResponse<T> { Items = items, Total = total };
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
