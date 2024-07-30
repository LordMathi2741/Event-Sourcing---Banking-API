using Banking.Account.Domain.Model.Aggregates;
using Banking.Account.Domain.Repositories;

namespace Banking.Account.Interfaces.ACL.Services;

public class AccountContextFacade(IAccountDetailRepository accountDetailRepository) : IAccountContextFacade
{
    public async Task<AccountDetail?> GetAccountDetailByIdAsync(long id)
    {
        return await accountDetailRepository.GetByIdAsync(id);
    }
}