using Banking.Account.Domain.Model.Exceptions;
using Banking.Shared.Domain.Repositories;
using Banking.Transfering.Application.OutboundServices.ACL;
using Banking.Transfering.Domain.Model.Aggregates;
using Banking.Transfering.Domain.Model.Commands;
using Banking.Transfering.Domain.Repositories;
using Banking.Transfering.Domain.Services;

namespace Banking.Transfering.Application.CommandServices;

public class TransactionCommandService(IUnitOfWork unitOfWork, ITransactionRepository transactionRepository, IExternalAccountService externalAccountService) : ITransactionCommandService
{
    public async Task<Transaction> Handle(CreateTransactionCommand command)
    {
        var account = await externalAccountService.GetAccountDetailByIdAsync(command.AccountId);
        if (account == null)
        {
            throw new AccountNotFoundException(command.AccountId);
        }
        var transaction = new Transaction(command);
        await transactionRepository.AddAsync(transaction);
        await unitOfWork.CompleteAsync();
        return transaction;
    }
}