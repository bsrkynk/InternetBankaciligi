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
    public class AmountTypeWalletMap : IEntityTypeConfiguration<AmountTypeWallet>
    {
        public void Configure(EntityTypeBuilder<AmountTypeWallet> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd(); ; // bir bir artmasını sağlamaktadır.
     
            builder.ToTable("AmountTypeWallets");
        }
    }
}
