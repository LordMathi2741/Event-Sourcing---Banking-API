using Banking.Transfering.Domain.Model.Commands;
namespace Banking.Transfering.Domain.Model.Aggregates;

public partial class Transaction
{
    public long Id { get; }
    public double Amount { get; }
    public long AccountId { get; }
    
    public DateTimeOffset CreatedAt { get; }
}

public partial class Transaction
{
    public Transaction()
    {
        Amount = 0.00;
    }

    public Transaction(CreateTransactionCommand command)
    {
        Amount = command.Amount;
        AccountId = command.AccountId;
        CreatedAt = DateTimeOffset.Now;
    }
}