using TestAppCRM.Application.Interfaces;
using TestAppCRM.DataAccess.Context;

namespace TestAppCRM.DataAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly TestAppCrmDbContext _context;
    private bool _disposed;

    public UnitOfWork(TestAppCrmDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}