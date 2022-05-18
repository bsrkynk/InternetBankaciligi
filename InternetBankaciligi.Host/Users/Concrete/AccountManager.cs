using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBankaciligi.Data.Concrete.EntityFramework.Contexts;
using InternetBankaciligi.Data.Abstract;
using InternetBankaciligi.Entities.Dtos;
using InternetBankaciligi.Host.Users.Abstract;
using InternetBankaciligi.Host.Extensions;
using InternetBankaciligi.Entities.Concrete;
using System.Security.Cryptography;

namespace InternetBankaciligi.Host.Users.Concrete
{
    public class AccountManager : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWalletService _walletService;

        public AccountManager(IUnitOfWork unitOfWork,IWalletService walletService)
        {
            _unitOfWork = unitOfWork;
            _walletService = walletService;
        }

        public async Task<List<Account>> GetAllUserAccounts(int userId)
        {
            var result = await _unitOfWork.Accounts.GetAllAsync(a => a.UserId == userId);
            return result.ToList();
        }
        public async Task<List<Account>> GetUserAccount(int accountId)
        {
            var result = await _unitOfWork.Accounts.GetAllAsync(a => a.Id == accountId);
            return result.ToList();
        }
        public async Task<int>  GetWalletIdWithIbanFromAccount(string iban)
        {
            var result = await _unitOfWork.Accounts.GetAsync(a => a.Iban == iban);
            var walletId = result.WalletId;
            return  walletId;
        }
        public async Task<int> GetAccountIdWithIbanFromAccount(string iban)
        {
            var result = await _unitOfWork.Accounts.GetAsync(a => a.Iban == iban);
            var walletId = result.Id;
            return walletId;
        }

        public async Task AddAccount(CreateAccountDto createAccountDto)
        {
            Account account = new Account
            {
                AccountName = createAccountDto.AccountName,
                UserId = createAccountDto.UserId,

                IsActive = true,
                IsDeleted = false
            };

            await _unitOfWork.Accounts.AddAsync(account);
            await _unitOfWork.SaveAsync();

            int createdAccountId = account.Id;
            int createdWalletId = await _walletService.InitialWalletCreate(createdAccountId); //her accountın bir wallet ı olacağı için account oluşturulurken wallet da oluşturuluyor
            var accounts = await _unitOfWork.Accounts.GetAllAsync(x => x.Id == createdAccountId);
            var createdAccount = accounts.FirstOrDefault();
            createdAccount.WalletId = createdWalletId;
            _unitOfWork.Accounts.DetachEntity();
            Account acountss = new Account  //oluşturulan wallet account tablosuna kaydediliyor
            {
                AccountName = createAccountDto.AccountName,
                UserId = createAccountDto.UserId,
                IsActive = true,
                IsDeleted = false,
                WalletId = createdAccount.WalletId,
                Iban = IbanCalculator.GenerateIban(createdAccount.Id.ToString()),
                Id = createdAccount.Id
            };

            await _unitOfWork.Accounts.UpdateAsync(acountss);
            await _unitOfWork.SaveAsync();
        }
    }
}
