namespace Banking.Account.Domain.Model.Events;

public record AccountBalanceAddEvent(long Id,double Amount,DateTimeOffset TransferAt);