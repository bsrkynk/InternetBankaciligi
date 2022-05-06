using InternetBankaciligi.Data.Abstract;
using InternetBankaciligi.Entities.Concrete;
using InternetBankaciligi.Shared.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Data.Concrete.EntityFramework.Repositories
{
    public class AmountTypeWalletRepository: EfEntityRepositoryBase<AmountTypeWallet>, IAmountTypeWallet
    {
        public AmountTypeWalletRepository(DbContext context) : base(context)
        {
        }
    }
}
