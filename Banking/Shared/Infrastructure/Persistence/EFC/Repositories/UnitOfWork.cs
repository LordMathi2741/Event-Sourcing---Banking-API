using Banking.Shared.Domain.Repositories;
using Banking.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Banking.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}