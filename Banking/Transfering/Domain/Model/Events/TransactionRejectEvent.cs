namespace Banking.Transfering.Domain.Model.Events;

public record TransactionRejectEvent(long Id, DateTimeOffset RejectedAt);