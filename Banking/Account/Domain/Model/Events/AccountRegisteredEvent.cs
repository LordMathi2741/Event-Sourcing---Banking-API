namespace Banking.Account.Domain.Model.Events;

public record AccountRegisteredEvent(long Id, DateTimeOffset RegisteredAt);