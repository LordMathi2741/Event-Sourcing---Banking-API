using Banking.Account.Domain.Model.Aggregates;

namespace Banking.Transfering.Application.OutboundServices.ACL;

public interface IExternalAccountService
{
    Task<AccountDetail?> GetAccountDetailByIdAsync(long id);
    Task AccountBalanceSubtractAsync(long id, double amount, DateTimeOffset transferAt);
    Task AccountBalanceAddAsync(long id, double amount, DateTimeOffset transferAt);
    
}