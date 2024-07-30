namespace Banking.Transfering.Domain.Model.Queries;

public record GetTotalBalanceByAccountIdAndYearQuery(long AccountId, int Year);