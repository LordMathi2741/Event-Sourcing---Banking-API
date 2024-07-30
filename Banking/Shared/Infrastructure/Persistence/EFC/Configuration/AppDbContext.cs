using Banking.Account.Domain.Model.Aggregates;
using Banking.Account.Domain.Model.ValueObjects;
using Banking.Shared.Infrastructure.Persistence.EFC.Extensions;
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
        modelBuilder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}