using Banking.Shared.Domain.Repositories;
using Banking.Transfering.Domain.Model.Aggregates;

namespace Banking.Transfering.Domain.Repositories;

public interface ITransactionRepository : IBaseRepository<Transaction>
{
    double GetCurrentBalanceByAccountId(long accountId);
    double GetCurrentBalanceByAccountIdAndYear(long accountId, int year);
}