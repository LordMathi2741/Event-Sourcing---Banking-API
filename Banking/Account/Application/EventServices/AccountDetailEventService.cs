using Banking.Account.Domain.Model.Entities;
using Banking.Account.Domain.Model.Events;
using Banking.Account.Domain.Model.ValueObjects;
using Banking.Account.Domain.Repositories;
using Banking.Account.Domain.Services;
using Banking.Shared.Domain.Repositories;

namespace Banking.Account.Application.EventServices;

public class AccountDetailEventService(IAccountDetailRepository accountDetailRepository,IAccountOperationRepository accountOperationRepository, IUnitOfWork unitOfWork) : IAccountDetailEventService
{
    public async Task Handle(AccountRegisteredEvent accountRegisteredEvent)
    {
        var account = await accountDetailRepository.GetByIdAsync(accountRegisteredEvent.Id);
        if (account != null)
        {
            var currentOperation = EAccountOperationTypes.Created.ToString();
            var accountOperation = new AccountOperation(currentOperation,account.Id);
            await accountOperationRepository.AddAsync(accountOperation);
        }
        await unitOfWork.CompleteAsync();
    }

    public async Task Handle(AccountBalanceAddEvent accountBalanceAddEvent)
    {
        var account = await accountDetailRepository.GetByIdAsync(accountBalanceAddEvent.Id);
        if (account != null)
        {
            var currentOperation = EAccountOperationTypes.AddTransaction.ToString();
            var accountOperation = new AccountOperation(currentOperation,account.Id);
            await accountOperationRepository.AddAsync(accountOperation);
        }
        await unitOfWork.CompleteAsync();
    }

    public async Task Handle(AccountBalanceSubtractEvent accountBalanceSubtractEvent)
    {
        var account = await accountDetailRepository.GetByIdAsync(accountBalanceSubtractEvent.Id);
        if (account != null)
        {
            var currentOperation = EAccountOperationTypes.SubtractTransaction.ToString();
            var accountOperation = new AccountOperation(currentOperation,account.Id);
            await accountOperationRepository.AddAsync(accountOperation);
        }
        await unitOfWork.CompleteAsync();
    }
    
}