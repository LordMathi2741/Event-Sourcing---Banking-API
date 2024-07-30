using Banking.Account.Domain.Model.Aggregates;
using Banking.Account.Interfaces.REST.Resources;

namespace Banking.Account.Interfaces.REST.Transform;

public class AccountDetailResourceFromEntityAssembler
{
    public static AccountDetailResource ToResourceFromEntity(AccountDetail account)
    {
        return new AccountDetailResource(account.Id, account.Email, account.Password, account.FullName);
    }
}