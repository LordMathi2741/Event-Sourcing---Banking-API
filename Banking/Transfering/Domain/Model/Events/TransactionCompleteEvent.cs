namespace Banking.Transfering.Domain.Model.Events;

public record TransactionCompleteEvent(long Id, DateTimeOffset CompletedAt);