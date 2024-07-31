using Banking.Account.Domain.Model.Entities;
using Banking.Account.Domain.Repositories;
using Banking.Shared.Infrastructure.Persistence.EFC.Configuration;
using Banking.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Banking.Account.Infrastructure.Persistence.EFC.Repositories;

public class AccountOperationRepository (AppDbContext context): BaseRepository<AccountOperation>(context), IAccountOperationRepository
{
    
}