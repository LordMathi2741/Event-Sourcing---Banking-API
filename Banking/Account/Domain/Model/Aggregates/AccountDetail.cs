using Banking.Account.Domain.Model.Commands;
using Banking.Account.Domain.Model.ValueObjects;
using Banking.Transfering.Domain.Model.Aggregates;

namespace Banking.Account.Domain.Model.Aggregates;

public partial class AccountDetail
{
    public long Id { get; }
    public string Email { get;  }
    public string Password { get; }
    public Username Username {  get; }
    public DateTimeOffset CreatedDate { get; }
    public string FullName => Username.FullName;
}

public partial class AccountDetail
{
    public AccountDetail() 
    {
        Email = string.Empty;
        Password = string.Empty;
        Username = new Username();
    }

    public AccountDetail(CreateAccountDetailCommand detailCommand)
    {
        Email = detailCommand.Email;
        Password = detailCommand.Password;
        Username = new Username(detailCommand.FirstName, detailCommand.LastName);
        CreatedDate = DateTimeOffset.UtcNow;
    }
}