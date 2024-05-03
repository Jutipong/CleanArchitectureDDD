using Domain.Interfaces;
using Infrastructure.Databases.SqlServer;

namespace Infrastructure.Abstractions.EfCore;

public class UnitOfWork : IUnitOfWork
{
    private readonly SqlContext _context;

    public UnitOfWork(SqlContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
