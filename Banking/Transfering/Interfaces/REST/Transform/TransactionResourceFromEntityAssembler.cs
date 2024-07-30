using Banking.Transfering.Domain.Model.Aggregates;
using Banking.Transfering.Interfaces.REST.Resources;

namespace Banking.Transfering.Interfaces.REST.Transform;

public class TransactionResourceFromEntityAssembler
{
    public static TransactionResource ToResourceFromEntity(Transaction transaction)
    {
        return new TransactionResource(transaction.Id, transaction.Amount, transaction.AccountId);
    }
}