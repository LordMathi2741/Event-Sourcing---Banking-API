namespace Banking.Transfering.Interfaces.REST.Resources;

public record CreateTransactionResource(double Amount, long AccountId);