namespace Banking.Account.Domain.Model.Commands;

public record CreateAccountDetailCommand(string Email, string Password, string FirstName, string LastName);