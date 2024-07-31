using Banking.Account.Domain.Model.Entities;
using Banking.Shared.Domain.Repositories;

namespace Banking.Account.Domain.Repositories;

public interface IAccountOperationRepository : IBaseRepository<AccountOperation>
{
    
}