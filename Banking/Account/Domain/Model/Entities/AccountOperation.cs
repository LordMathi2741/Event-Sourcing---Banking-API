namespace Banking.Account.Domain.Model.Entities;

public partial class AccountOperation
{
    public long Id { get;  }
    public string Operation { get;  } = operation;
    public long AccountId { get; } = accountId;

    public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;
}

public partial class AccountOperation(string operation, long accountId);