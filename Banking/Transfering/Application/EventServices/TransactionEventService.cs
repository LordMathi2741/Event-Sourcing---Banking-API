using Banking.Shared.Domain.Repositories;
using Banking.Transfering.Domain.Model.Entities;
using Banking.Transfering.Domain.Model.Events;
using Banking.Transfering.Domain.Model.ValueObjects;
using Banking.Transfering.Domain.Repositories;
using Banking.Transfering.Domain.Services;

namespace Banking.Transfering.Application.EventServices;

internal class TransactionEventService(IUnitOfWork unitOfWork, ITransactionRepository transactionRepository, ITransactionStateRepository transactionStateRepository) : ITransactionEventService
{
    public async Task Handle(TransactionCompleteEvent transactionCompleteEvent)
    {
        var transaction = await transactionRepository.GetByIdAsync(transactionCompleteEvent.Id);
        var currentOperation = ETransactionStateTypes.Completed.ToString();
        var transactionState = new TransactionState(currentOperation, transaction.Id);
        await transactionStateRepository.AddAsync(transactionState);
        await unitOfWork.CompleteAsync();
    }

    public async Task Handle(TransactionRejectEvent transactionRejectEvent)
    {
        var transaction = await transactionRepository.GetByIdAsync(transactionRejectEvent.Id);
        var currentOperation = ETransactionStateTypes.Rejected.ToString();
        var transactionState = new TransactionState(currentOperation, transaction.Id);
        await transactionStateRepository.AddAsync(transactionState);
        await unitOfWork.CompleteAsync();
    }
}