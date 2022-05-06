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
    public class AmountTypeWalletManager : IAmountTypeWalletService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AmountTypeWalletManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<AmountTypeWalletJoin>> GetUserWallet(int accountId)
        {
            var userWallet = await _unitOfWork.AmountTypeWallets.GetAllAsync(x => x.Wallet.AccountId == accountId, y => y.Wallet, z => z.AmountType);
            var uw = userWallet.Select(x => new AmountTypeWalletJoin { AmountTypeName = x.AmountType.AmountName, AmountOfAmountType = x.AmountOfAmountType , TotalWelthOfWallet = x.Wallet.TotalWealth, AvarageBuyPrice = x.AvarageBuyPrice, TotalWelthOfAmountType = x.TotalWelthOfAmountType }).ToList();         
            return uw.ToList();
        }
        public async Task AddAmountTypeWallet(int amountTypeId, int walletId)
        {
            var isExist = await _unitOfWork.AmountTypeWallets.AnyAsync(x => x.AmountTypeId == amountTypeId && x.WalletId == walletId);
            if (!isExist)
            {
                AmountTypeWallet addAmountTypeWallet = new AmountTypeWallet
                {
                    AmountTypeId = amountTypeId,
                    WalletId = walletId,
                    IsActive = true,
                    IsDeleted = false,
                    AmountOfAmountType = "0",
                    AvarageBuyPrice = "0",
                    TotalWelthOfAmountType = "0"

                };
                await _unitOfWork.AmountTypeWallets.AddAsync(addAmountTypeWallet);
                await _unitOfWork.SaveAsync();
            }
        }
        public async Task<IEnumerable<AmountTypeWalletJoin>> GetUnifiedAmountTypeWallet(int amountTypeId, int walletId)
        {
            var coinWallet = await _unitOfWork.AmountTypeWallets.GetAllAsync(x => x.WalletId == walletId && x.AmountTypeId == amountTypeId); //x numaralı wallettaki y numaralı amounttypeı getirir
            var coin = await _unitOfWork.AmountTypes.GetAllAsync(x => x.Id == amountTypeId);
            var wallet = await _unitOfWork.Wallets.GetAllAsync(x => x.Id == walletId);
            var query = from cw in coinWallet
                        join
                            c in coin on cw.AmountTypeId equals c.Id
                        join w in wallet on cw.WalletId equals w.Id
                        select new AmountTypeWalletJoin
                        {
                            AmountTypeId = c.Id,
                            WalletId = w.Id,
                            AmountPrice = c.AmountPrice,
                            TotalWelthOfWallet = w.TotalWealth,
                            AvarageBuyPrice = cw.AvarageBuyPrice,
                            AmountOfAmountType = cw.AmountOfAmountType,
                            AccountId = w.AccountId,
                            AmountTypeWalletId = cw.Id,
                            TotalWelthOfAmountType = cw.TotalWelthOfAmountType
                        };
            return query.ToList();
        }
    }
}
