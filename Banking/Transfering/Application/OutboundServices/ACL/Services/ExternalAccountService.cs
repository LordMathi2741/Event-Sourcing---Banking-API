using Banking.Account.Domain.Model.Aggregates;
using Banking.Account.Domain.Model.Events;
using Banking.Account.Domain.Model.Queries;
using Banking.Account.Domain.Services;

namespace Banking.Transfering.Application.OutboundServices.ACL.Services;

public class ExternalAccountService(IAccountDetailQueryService accountDetailQueryService, IAccountDetailEventService accountDetailEventService) : IExternalAccountService
{
    public async Task<AccountDetail?> GetAccountDetailByIdAsync(long id)
    {
        var query = new GetAccountByIdQuery(id);
        return await accountDetailQueryService.Handle(query);
    }

    public async Task AccountBalanceSubtractAsync(long id, double amount, DateTimeOffset transferAt)
    {
        var accountEvent = new AccountBalanceSubtractEvent(id, amount, transferAt);
        await accountDetailEventService.Handle(accountEvent);
    }

    public async Task AccountBalanceAddAsync(long id, double amount, DateTimeOffset transferAt)
    {
        var accountEvent = new AccountBalanceAddEvent(id, amount, transferAt);
        await accountDetailEventService.Handle(accountEvent);
    }
}