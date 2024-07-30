using Banking.Account.Domain.Model.Aggregates;
using Banking.Account.Domain.Model.Queries;

namespace Banking.Account.Domain.Services;

public interface IAccountDetailQueryService
{
    Task<AccountDetail?> Handle(GetAccountByIdQuery query);
    Task<IEnumerable<AccountDetail>> Handle(GetAllAccountsQuery query);
}