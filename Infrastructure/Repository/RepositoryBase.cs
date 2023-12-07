using Infrastructure.Databases.SqlServer;

namespace Infrastructure.Repository;

public abstract class RepositoryBase<TEntity>
    where TEntity : class
{
    protected readonly SqlContext _sqlContext;

    protected RepositoryBase(SqlContext sqlContext)
    {
        _sqlContext = sqlContext;
    }

    public virtual void Add(TEntity entity)
    {
        _sqlContext.Add(entity);
    }

    public virtual void AddRange(IEnumerable<TEntity> entities)
    {
        _sqlContext.AddRange(entities);
    }

    public virtual void Remove(TEntity entity)
    {
        _sqlContext.Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<TEntity> entities)
    {
        _sqlContext.RemoveRange(entities);
    }
}