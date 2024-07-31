using Banking.Account.Domain.Model.Exceptions;
using Banking.Shared.Domain.Repositories;
using Banking.Transfering.Application.OutboundServices.ACL;
using Banking.Transfering.Domain.Model.Aggregates;
using Banking.Transfering.Domain.Model.Commands;
using Banking.Transfering.Domain.Model.Events;
using Banking.Transfering.Domain.Repositories;
using Banking.Transfering.Domain.Services;

namespace Banking.Transfering.Application.CommandServices;

public class TransactionCommandService(IUnitOfWork unitOfWork, ITransactionRepository transactionRepository, IExternalAccountService externalAccountService, ITransactionEventService transactionEventService) : ITransactionCommandService
{
    public async Task<Transaction> Handle(CreateTransactionCommand command)
    {
        var account = await externalAccountService.GetAccountDetailByIdAsync(command.AccountId);
        if (account == null)
        {
            throw new AccountNotFoundException(command.AccountId);
        }
        var transaction = new Transaction(command);
        if (transaction.Amount < 0)
        {
            await externalAccountService.AccountBalanceSubtractAsync(transaction.AccountId, transaction.Amount, transaction.CreatedAt);
        }
        else 
        {
            await externalAccountService.AccountBalanceAddAsync(transaction.AccountId, transaction.Amount, transaction.CreatedAt);
        }
        
        await transactionRepository.AddAsync(transaction);
        await unitOfWork.CompleteAsync();
        if (transaction.Amount == 0)
        {
            var transactionEvent = new TransactionRejectEvent(transaction.Id, transaction.CreatedAt);
            await transactionEventService.Handle(transactionEvent);
        }
        else
        {
            var transactionEvent = new TransactionCompleteEvent(transaction.Id, transaction.CreatedAt);
            await transactionEventService.Handle(transactionEvent);
        }
        return transaction;
    }
}