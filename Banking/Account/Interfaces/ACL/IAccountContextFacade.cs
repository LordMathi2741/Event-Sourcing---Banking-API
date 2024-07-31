using Banking.Account.Domain.Model.Aggregates;

namespace Banking.Account.Interfaces.ACL;

public interface IAccountContextFacade
{
    Task<AccountDetail?> GetAccountDetailByIdAsync(long id);
    Task AccountBalanceSubtractAsync(long id, double amount, DateTime transferAt);
    Task AccountBalanceAddAsync(long id, double amount, DateTime transferAt);
}