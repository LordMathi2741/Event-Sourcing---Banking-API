using Banking.Transfering.Domain.Model.Queries;

namespace Banking.Transfering.Domain.Services;

public interface ITransactionQueryService
{
    double Handle(GetTotalBalanceByAccountIdQuery query);
    double Handle(GetTotalBalanceByAccountIdAndYearQuery query);
}