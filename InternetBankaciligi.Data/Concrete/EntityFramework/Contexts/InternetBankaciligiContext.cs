using InternetBankaciligi.Data.Concrete.EntityFramework.Mapping;
using InternetBankaciligi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Data.Concrete.EntityFramework.Contexts
{
    public class InternetBankaciligiContext: DbContext
    {
        public DbSet<AccountAmountType> AccountAmountTypes { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AmountType> AmountTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=InternetBankaciligi;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AccountAmountTypeMap());
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new AmountTypeMap());
            modelBuilder.ApplyConfiguration(new TransactionMap());
            modelBuilder.ApplyConfiguration(new UserMap());

        }

    }
}
