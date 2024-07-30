namespace Banking.Transfering.Domain.Model.Commands;

public record CreateTransactionCommand(double Amount, long AccountId);