using Banking.Account.Domain.Model.Aggregates;
using Banking.Account.Domain.Model.Entities;
using Banking.Shared.Infrastructure.Persistence.EFC.Extensions;
using Banking.Transfering.Domain.Model.Aggregates;
using Banking.Transfering.Domain.Model.Entities;
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
        
        modelBuilder.Entity<AccountOperation>().HasKey(a => a.Id);
        modelBuilder.Entity<AccountOperation>().Property(a => a.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<AccountOperation>().Property(a => a.Operation).IsRequired();
        modelBuilder.Entity<AccountOperation>().Property(a => a.CreatedAt).IsRequired();
        
        modelBuilder.Entity<TransactionState>().HasKey(a => a.Id);
        modelBuilder.Entity<TransactionState>().Property(a => a.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<TransactionState>().Property(a => a.Operation).IsRequired();
        modelBuilder.Entity<TransactionState>().Property(a => a.CreatedAt).IsRequired();

        modelBuilder.Entity<Transaction>().HasMany<TransactionState>().WithOne().HasForeignKey(t => t.TransactionId);

        modelBuilder.Entity<AccountDetail>().HasMany<AccountOperation>().WithOne().HasForeignKey(a => a.AccountId);

        modelBuilder.Entity<Transaction>().HasOne<AccountDetail>().WithMany().HasForeignKey(t => t.AccountId);
        modelBuilder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}