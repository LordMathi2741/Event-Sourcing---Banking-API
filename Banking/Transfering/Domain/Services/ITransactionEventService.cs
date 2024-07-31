using Banking.Transfering.Domain.Model.Events;

namespace Banking.Transfering.Domain.Services;

public interface ITransactionEventService
{
    Task Handle(TransactionCompleteEvent transactionCompleteEvent);
    Task Handle(TransactionRejectEvent transactionRejectEvent);
}