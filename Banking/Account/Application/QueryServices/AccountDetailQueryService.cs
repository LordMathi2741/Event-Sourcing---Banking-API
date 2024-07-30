using Banking.Account.Domain.Model.Aggregates;
using Banking.Account.Domain.Model.Queries;
using Banking.Account.Domain.Repositories;
using Banking.Account.Domain.Services;

namespace Banking.Account.Application.QueryServices;

public class AccountDetailQueryService(IAccountDetailRepository accountDetailRepository) : IAccountDetailQueryService
{
    public async Task<AccountDetail?> Handle(GetAccountByIdQuery query)
    {
        return await accountDetailRepository.GetByIdAsync(query.Id);
    }

    public async Task<IEnumerable<AccountDetail>> Handle(GetAllAccountsQuery query)
    {
        return await accountDetailRepository.GetAllAsync();
    }
}