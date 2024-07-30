using Banking.Transfering.Domain.Model.Queries;
using Banking.Transfering.Domain.Repositories;
using Banking.Transfering.Domain.Services;

namespace Banking.Transfering.Application.QueryServices;

public class TransactionQueryService(ITransactionRepository transactionRepository) : ITransactionQueryService
{
    public double Handle(GetTotalBalanceByAccountIdQuery query)
    {
        return transactionRepository.GetCurrentBalanceByAccountId(query.AccountId);
    }

    public double Handle(GetTotalBalanceByAccountIdAndYearQuery query)
    {
        return transactionRepository.GetCurrentBalanceByAccountIdAndYear(query.AccountId, query.Year);
    }
}