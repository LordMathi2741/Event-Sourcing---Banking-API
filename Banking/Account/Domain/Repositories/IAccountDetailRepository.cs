using Banking.Account.Domain.Model.Aggregates;
using Banking.Shared.Domain.Repositories;

namespace Banking.Account.Domain.Repositories;

public interface IAccountDetailRepository : IBaseRepository<AccountDetail>
{
    Task<AccountDetail?> GetAccountDetailByEmailAndPasswordAsync(string email, string password);
}