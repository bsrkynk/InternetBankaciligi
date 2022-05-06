using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBankaciligi.Entities.Dtos;

namespace InternetBankaciligi.Host.Users.Abstract
{
    public interface IAmountTypeWalletService
    {
        public Task<List<AmountTypeWalletJoin>> GetUserWallet(int portfolioId);
        Task AddAmountTypeWallet(int amountTypeId, int walletId);
        Task<IEnumerable<AmountTypeWalletJoin>> GetUnifiedAmountTypeWallet(int amountTypeId, int walletId);
    }
}
