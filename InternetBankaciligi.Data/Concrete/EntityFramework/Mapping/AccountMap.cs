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

            builder.Property(a => a.AccountTypeName).HasMaxLength(100);
            builder.HasIndex(a => a.AccountTypeName).IsUnique(true);
            builder.Property(a => a.AccountTypeName).IsRequired(true);

            builder.Property(a => a.IsDeleted).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true);

            builder.HasOne<User>(a => a.User).WithMany(a => a.Accounts).HasForeignKey(a => a.UserId);

            builder.ToTable("Accounts");

        }
    }
}
