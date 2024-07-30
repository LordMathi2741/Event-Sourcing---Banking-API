using Banking.Account.Domain.Model.Aggregates;
using Banking.Account.Domain.Model.Commands;

namespace Banking.Account.Domain.Services;

public interface IAccountDetailCommandService
{
    Task<AccountDetail> Handle(CreateAccountDetailCommand command);
}