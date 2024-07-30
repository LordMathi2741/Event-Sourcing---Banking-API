using Banking.Account.Domain.Model.Aggregates;
using Banking.Shared.Infrastructure.Persistence.EFC.Extensions;
using Banking.Transfering.Domain.Model.Aggregates;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Banking.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<AccountDetail>().HasKey(a => a.Id);
        modelBuilder.Entity<AccountDetail>().Property(a => a.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<AccountDetail>().Property(a => a.Email).IsRequired();
        modelBuilder.Entity<AccountDetail>().Property(a => a.Password).IsRequired();
        modelBuilder.Entity<AccountDetail>().OwnsOne(a => a.Username, u =>
        {
            u.WithOwner().HasForeignKey("Id");
            u.Property(un => un.FirstName).HasColumnName("FirstName");
            u.Property(un => un.LastName).HasColumnName("LastName");
        });
        modelBuilder.Entity<AccountDetail>().Property(a => a.CreatedDate).IsRequired();
        
        modelBuilder.Entity<Transaction>().HasKey(a => a.Id);
        modelBuilder.Entity<Transaction>().Property(a => a.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Transaction>().Property(a => a.Amount).IsRequired();
        modelBuilder.Entity<Transaction>().Property(a => a.CreatedAt).IsRequired();
        
        modelBuilder.Entity<Transaction>().HasOne(t => t.Account).WithMany(a => a.Transactions).HasForeignKey( t => t.AccountId);
        modelBuilder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}