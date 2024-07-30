using Banking.Account.Domain.Model.Aggregates;
using Banking.Account.Domain.Model.Commands;
using Banking.Account.Domain.Model.Exceptions;
using Banking.Account.Domain.Repositories;
using Banking.Account.Domain.Services;
using Banking.Shared.Domain.Repositories;

namespace Banking.Account.Application.CommandServices;

public class AccountDetailCommandService(IAccountDetailRepository accountDetailRepository, IUnitOfWork unitOfWork) : IAccountDetailCommandService
{
    public async Task<AccountDetail> Handle(CreateAccountDetailCommand command)
    {
        var account = new AccountDetail(command);
        var accountExist =
            await accountDetailRepository.GetAccountDetailByEmailAndPasswordAsync(command.Email, command.Password);
        if (accountExist != null)
        {
            throw new AccountWithThisEmailOrPasswordAlreadyExistException();
        }
        await accountDetailRepository.AddAsync(account);
        await unitOfWork.CompleteAsync();
        return account;
    }
}