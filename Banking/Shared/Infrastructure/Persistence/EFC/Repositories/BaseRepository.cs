using Banking.Shared.Domain.Repositories;
using Banking.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Banking.Shared.Infrastructure.Persistence.EFC.Repositories;

public class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    public async Task AddAsync(TEntity entity) => await context.Set<TEntity>().AddAsync(entity);

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().ToListAsync();
    }
    
    

    public async Task<TEntity?> GetByIdAsync(long id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }
}