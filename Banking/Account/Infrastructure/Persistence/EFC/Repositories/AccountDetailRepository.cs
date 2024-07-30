using Banking.Account.Domain.Model.Aggregates;
using Banking.Account.Domain.Repositories;
using Banking.Shared.Infrastructure.Persistence.EFC.Configuration;
using Banking.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Banking.Account.Infrastructure.Persistence.EFC.Repositories;

public class AccountDetailRepository(AppDbContext context) : BaseRepository<AccountDetail>(context), IAccountDetailRepository
{
    public async Task<AccountDetail?> GetAccountDetailByEmailAndPasswordAsync(string email, string password)
    {
        return await context.Set<AccountDetail>().Where(a => a.Email == email && a.Password == password).FirstOrDefaultAsync();
    }
}