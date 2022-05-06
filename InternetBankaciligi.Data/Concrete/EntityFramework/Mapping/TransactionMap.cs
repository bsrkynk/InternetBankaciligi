using InternetBankaciligi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InternetBankaciligi.Data.Concrete.EntityFramework.Mapping
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();//bir bir artmasını sağlıyor
            builder.Property(a => a.Amount).IsRequired(true);
            builder.Property(a => a.TransactionTypeName).HasMaxLength(100);
            builder.HasIndex(a => a.TransactionTypeName).IsUnique(false);
            builder.Property(a => a.TransactionTypeName).IsRequired(true);
            builder.Property(a => a.IsDeleted).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true);


            builder.HasOne<Account>(a => a.Account).WithMany(c => c.Transactions).HasForeignKey(a => a.AccountId);

            builder.Property(a => a.IsDeleted).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true);
            builder.ToTable("Transactions");
        }
    }
}
