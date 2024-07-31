using Banking.Account.Domain.Model.Aggregates;
using Banking.Account.Domain.Model.Events;
using Banking.Account.Domain.Repositories;
using Banking.Account.Domain.Services;

namespace Banking.Account.Interfaces.ACL.Services;

public class AccountContextFacade(IAccountDetailRepository accountDetailRepository, IAccountDetailEventService accountDetailEventService) : IAccountContextFacade
{
    public async Task<AccountDetail?> GetAccountDetailByIdAsync(long id)
    {
        return await accountDetailRepository.GetByIdAsync(id);
    }

    public async Task AccountBalanceSubtractAsync(long id, double amount, DateTime transferAt)
    {
        var accountEvent = new AccountBalanceSubtractEvent(id,amount, transferAt);
        await accountDetailEventService.Handle(accountEvent);
    }

    public async Task AccountBalanceAddAsync(long id, double amount, DateTime transferAt)
    {
        var accountEvent = new AccountBalanceAddEvent(id,amount, transferAt);
       await accountDetailEventService.Handle(accountEvent);
    }
}