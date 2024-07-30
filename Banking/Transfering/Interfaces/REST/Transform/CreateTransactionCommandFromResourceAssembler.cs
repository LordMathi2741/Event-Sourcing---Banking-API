using Banking.Transfering.Domain.Model.Commands;
using Banking.Transfering.Interfaces.REST.Resources;

namespace Banking.Transfering.Interfaces.REST.Transform;

public class CreateTransactionCommandFromResourceAssembler
{
    public static CreateTransactionCommand ToCommandFromResource(CreateTransactionResource createTransactionResource)
    {
        return new CreateTransactionCommand(createTransactionResource.Amount, createTransactionResource.AccountId);
    }
}