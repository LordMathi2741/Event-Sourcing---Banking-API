using Banking.Transfering.Domain.Model.Aggregates;
using Banking.Transfering.Domain.Model.Commands;

namespace Banking.Transfering.Domain.Services;

public interface ITransactionCommandService
{
    Task<Transaction> Handle(CreateTransactionCommand command);
}