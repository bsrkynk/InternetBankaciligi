using InternetBankaciligi.Data.Abstract;
using InternetBankaciligi.Entities.Concrete;
using InternetBankaciligi.Host.Users.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Host.Users.Concrete
{
    public class WalletManager:IWalletService
    {

        private readonly IUnitOfWork _unitOfWork;

        public WalletManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> InitialWalletCreate(int accountId) //account oluşturulurken wallet da boş olarak oluşturuluyor
        {
            Wallet wallet = new Wallet
            {
                IsActive = true,
                IsDeleted = false,
                TotalWealth = "0",
                AccountId = accountId
            };        
            await _unitOfWork.Wallets.AddAsync(wallet);
            await _unitOfWork.SaveAsync();
            return wallet.Id;
        }
        public async Task<int> GetCreatedWalletId(int accountId)
        {
            var wallet = await _unitOfWork.Wallets.GetAsync(x => x.AccountId == accountId);
            return wallet.Id;
        }
    }
}
