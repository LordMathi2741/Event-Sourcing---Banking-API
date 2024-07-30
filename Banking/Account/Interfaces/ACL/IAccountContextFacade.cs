using Banking.Account.Domain.Model.Aggregates;

namespace Banking.Account.Interfaces.ACL;

public interface IAccountContextFacade
{
    Task<AccountDetail?> GetAccountDetailByIdAsync(long id);
}