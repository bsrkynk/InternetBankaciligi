using InternetBankaciligi.Data.Abstract;
using InternetBankaciligi.Data.Concrete.EntityFramework.Contexts;
using InternetBankaciligi.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly InternetBankaciligiContext _context;
        private AmountTypeWalletRepository _accountAmountTypeRepository;
        private AccountRepository _accountRepository;
        private AmountTypeRepository _amountTypeRepository;
        private TransactionRepository _transactionRepository;
        private UserRepository _userRepository;
        private WalletRepository _walletRepository;
        public UnitOfWork(InternetBankaciligiContext context)
        {
            _context = context;
        }

        public IAmountTypeWallet AmountTypeWallets => _accountAmountTypeRepository ?? new AmountTypeWalletRepository(_context);

        public IAccountRepository Accounts => _accountRepository ?? new AccountRepository(_context);


        public IAmountTypeRepository AmountTypes => _amountTypeRepository ?? new AmountTypeRepository(_context);

        public ITransactionRepository Transactions => _transactionRepository ?? new TransactionRepository(_context);

        public IUserRepository Users => _userRepository ?? new UserRepository(_context);

        public IWalletRepository Wallets => _walletRepository ?? new WalletRepository(_context);


        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
