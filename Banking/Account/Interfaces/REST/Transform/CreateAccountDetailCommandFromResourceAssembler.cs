using Banking.Account.Domain.Model.Commands;
using Banking.Account.Interfaces.REST.Resources;

namespace Banking.Account.Interfaces.REST.Transform;

public class CreateAccountDetailCommandFromResourceAssembler
{
    public static CreateAccountDetailCommand ToCommandFromResource(CreateAccountDetailResource createAccountDetailResource)
    {
       return new CreateAccountDetailCommand(createAccountDetailResource.Email,createAccountDetailResource.Password,createAccountDetailResource.FirstName,createAccountDetailResource.LastName);
    }
}