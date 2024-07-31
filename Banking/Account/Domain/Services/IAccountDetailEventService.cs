using Banking.Account.Domain.Model.Events;

namespace Banking.Account.Domain.Services;

public interface IAccountDetailEventService
{
    Task Handle(AccountRegisteredEvent accountRegisteredEvent);
    Task Handle(AccountBalanceAddEvent accountBalanceAddEvent);
    Task Handle(AccountBalanceSubtractEvent accountBalanceSubtractEvent);
}