using Banking.Shared.Infrastructure.Persistence.EFC.Configuration;
using Banking.Shared.Infrastructure.Persistence.EFC.Repositories;
using Banking.Transfering.Domain.Model.Aggregates;
using Banking.Transfering.Domain.Repositories;

namespace Banking.Transfering.Infrastructure.Persistence.EFC.Repositories;

public class TransactionRepository(AppDbContext context) : BaseRepository<Transaction>(context), ITransactionRepository
{
    public double GetCurrentBalanceByAccountId(long accountId)
    {
        return context.Set<Transaction>().Where(t => t.AccountId == accountId).Sum(t => t.Amount);
    }

    public double GetCurrentBalanceByAccountIdAndYear(long accountId, int year)
    {
        return context.Set<Transaction>().Where(t => t.AccountId == accountId && t.CreatedAt.Year == year).Sum(t => t.Amount);
    }
}