namespace Banking.Account.Domain.Model.Exceptions;

public class AccountWithThisEmailOrPasswordAlreadyExistException : Exception
{
    public AccountWithThisEmailOrPasswordAlreadyExistException() : base("Account with this email or password already exist.")
    {
    }
}