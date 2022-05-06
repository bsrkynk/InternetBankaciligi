using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Host.Users.Abstract
{
    public interface IWalletService
    {
        Task<int> InitialWalletCreate(int portfolioId);
        Task<int> GetCreatedWalletId(int accountId);
    }
}
