namespace Banking.Transfering.Domain.Model.Entities;

public partial class TransactionState
{
    public long Id { get; }
    public string Operation { get; } = operation;
    public long TransactionId { get; } = transactionId;
    public DateTimeOffset CreatedAt { get; } = DateTimeOffset.Now;
}

public partial class TransactionState(string operation, long transactionId);