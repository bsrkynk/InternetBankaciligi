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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Name).IsRequired(true);

            builder.Property(a => a.Surname).HasMaxLength(100);
            builder.Property(a => a.Surname).IsRequired(true);
            builder.Property(a => a.Surname).HasMaxLength(100);

            builder.Property(a => a.TCNo).HasMaxLength(100);
            builder.Property(a => a.TCNo).IsRequired(true);
            builder.HasIndex(a => a.TCNo).IsUnique(true);

            builder.Property(a => a.CustomerNo).HasMaxLength(100);
            builder.HasIndex(a => a.CustomerNo).IsUnique(true);

            builder.Property(a => a.Password).HasMaxLength(100);
            builder.Property(a => a.Password).IsRequired(true);

            builder.Property(a => a.IsDeleted).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true);

            builder.ToTable("Users");
        }
    }
}
