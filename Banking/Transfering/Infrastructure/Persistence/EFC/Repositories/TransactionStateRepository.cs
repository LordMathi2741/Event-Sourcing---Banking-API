using Banking.Shared.Infrastructure.Persistence.EFC.Configuration;
using Banking.Shared.Infrastructure.Persistence.EFC.Repositories;
using Banking.Transfering.Domain.Model.Entities;
using Banking.Transfering.Domain.Repositories;

namespace Banking.Transfering.Infrastructure.Persistence.EFC.Repositories;

public class TransactionStateRepository(AppDbContext context) : BaseRepository<TransactionState>(context), ITransactionStateRepository
{
    
}