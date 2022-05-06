using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAmountTypeWallet AmountTypeWallets { get; }
        IAccountRepository Accounts { get; }
        IAmountTypeRepository AmountTypes { get; }
        ITransactionRepository Transactions { get; }
        IUserRepository Users { get; }
        IWalletRepository Wallets { get; }
        Task<int> SaveAsync();
    }
}
