namespace Banking.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}