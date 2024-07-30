using Banking.Account.Domain.Model.Aggregates;
using Banking.Account.Domain.Model.Queries;
using Banking.Account.Domain.Services;

namespace Banking.Transfering.Application.OutboundServices.ACL.Services;

public class ExternalAccountService(IAccountDetailQueryService accountDetailQueryService) : IExternalAccountService
{
    public async Task<AccountDetail?> GetAccountDetailByIdAsync(long id)
    {
        var query = new GetAccountByIdQuery(id);
        return await accountDetailQueryService.Handle(query);
    }
}