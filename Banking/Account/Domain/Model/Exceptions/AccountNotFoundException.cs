namespace Banking.Account.Domain.Model.Exceptions;

public class AccountNotFoundException : Exception
{
    public AccountNotFoundException(long  accountId) : base($"Account with id {accountId} not found.")
    {
    }
}