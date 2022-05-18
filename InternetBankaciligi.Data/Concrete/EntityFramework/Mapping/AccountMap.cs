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
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();//bir bir artmasını sağlıyor

            builder.HasOne<User>(a => a.User).WithMany(c => c.Accounts ).HasForeignKey(a => a.UserId);
            builder.HasOne<Wallet>(a => a.Wallet).WithOne(c => c.Account)
                .HasForeignKey<Wallet>(v => v.AccountId);     
            builder.Property(a => a.IsDeleted).IsRequired(true);

            builder.Property(a => a.IsActive).IsRequired(true);

            builder.ToTable("Accounts");

        }
    }
}
