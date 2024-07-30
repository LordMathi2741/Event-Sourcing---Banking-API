namespace Banking.Account.Interfaces.REST.Resources;

public record CreateAccountDetailResource(string Email, string Password, string FirstName, string LastName);