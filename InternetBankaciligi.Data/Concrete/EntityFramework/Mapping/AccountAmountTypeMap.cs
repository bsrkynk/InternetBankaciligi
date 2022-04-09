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
    public class AccountAmountTypeMap : IEntityTypeConfiguration<AccountAmountType>
    {
        public void Configure(EntityTypeBuilder<AccountAmountType> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd(); ; // bir bir artmasını sağlamaktadır.

            builder.Property(a => a.Amount).IsRequired(true);

            builder.ToTable("AccountAmountTypes");
        }
    }
}
