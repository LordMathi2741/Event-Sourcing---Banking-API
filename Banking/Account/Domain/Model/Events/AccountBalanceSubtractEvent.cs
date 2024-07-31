namespace Banking.Account.Domain.Model.Events;

public record AccountBalanceSubtractEvent(long Id,double Amount,DateTimeOffset TransferAt);