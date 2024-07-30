namespace Banking.Account.Domain.Model.ValueObjects;

public record Username(string FirstName, string LastName)
{
    public Username() : this(string.Empty, string.Empty)
    {
        
    }
    
    public Username(string firstName): this(firstName, string.Empty)
    {
        
    }
    
    public string FullName => $"{FirstName} {LastName}";
}