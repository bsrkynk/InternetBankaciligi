using InternetBankaciligi.Data.Abstract;
using InternetBankaciligi.Entities.Concrete;
using InternetBankaciligi.Entities.Dtos;
using InternetBankaciligi.Host.Users.Abstract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Host.Users.Concrete
{
    public class TransactionManager : ITransactionService
    {
        public enum Side
        {
            Deposit = 1,
            Drawing = 2,
            Transfer= 3
        }
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAmountTypeService _amountTypeService;
        private readonly IWalletService _walletService;
        private readonly IAmountTypeWalletService _amountTypeWalletService;
        private readonly IAccountService _accountService;
        public TransactionManager(IUnitOfWork unitOfWork, IAmountTypeService amountTypeService, IWalletService walletService, IAmountTypeWalletService amountTypeWalletService,IAccountService accountService)
        {
            _unitOfWork = unitOfWork;
            _amountTypeService = amountTypeService;
            _walletService = walletService;
            _amountTypeWalletService = amountTypeWalletService;
            _accountService = accountService;
        }
        public async Task<bool> ManageTransaction(CreateTransactionDto addTransactionDto, int instanceAccountId)
        {
            var addedAmountType = await _amountTypeService.AddAmountType(addTransactionDto);
            var addedWallet = await _walletService.GetCreatedWalletId(instanceAccountId);// her accountta bir wallet olacağı için çoka çok tablosuna kayıt olması için accountidden id den o portföyün walletının idsi bulunuyor.

            await _amountTypeWalletService.AddAmountTypeWallet(addedAmountType, addedWallet);//coin wallet tablosuna kaydediyor.
            await AddTransaction(addTransactionDto, instanceAccountId);
            var unifiedWalletCoin = await _amountTypeWalletService.GetUnifiedAmountTypeWallet(addedAmountType, addedWallet);

            var amountType = await _unitOfWork.AmountTypes.GetAllAsync(x => x.AmountName == addTransactionDto.AmountTypeName);
            var amountType2 = await _unitOfWork.AmountTypeWallets.GetAllAsync(x => x.AmountType == amountType[0]);
            var x = amountType2.Select(x => x.AmountOfAmountType);
            if (addTransactionDto.TransactionType == "Drawing" && Int32.Parse(addTransactionDto.AmountTypeAmount) <= Int32.Parse(x.ToArray()[0]))
            {
                addTransactionDto.IsSuccess = true;
                await DoWalletTransaction(addTransactionDto, unifiedWalletCoin);
                return true;
            }
            else if (addTransactionDto.TransactionType == "Deposit")
            {
                addTransactionDto.IsSuccess = true;
                await DoWalletTransaction(addTransactionDto, unifiedWalletCoin);
                return true;
            }
            else if (addTransactionDto.TransactionType == "Transfer")
            {
                addTransactionDto.IsSuccess = true;
                await DoWalletTransaction(addTransactionDto, unifiedWalletCoin);
                return true;
            }
            else
            {
                addTransactionDto.IsSuccess = false;
                return false;
            }
        }
        public async Task AddTransaction(CreateTransactionDto addTransactionDto, int instanceAccountId)
        {
            Transaction transaction = new Transaction
            {
                AmountTypeName = addTransactionDto.AmountTypeName,
                TotalPrice = addTransactionDto.TotalAmount,
                Amount = addTransactionDto.AmountTypeAmount,
                AccountId = instanceAccountId,
                TransactionPrice = addTransactionDto.TotalAmount,
                IsActive = true,
                IsDeleted = false,
                TransactionTypeName = addTransactionDto.TransactionType.ToString()
            };
            await _unitOfWork.Transactions.AddAsync(transaction);
            await _unitOfWork.SaveAsync();
        }
        public async Task DoWalletTransaction(CreateTransactionDto createTransactionDto, IEnumerable<AmountTypeWalletJoin> joinedAmountTypeWallet)
        {
            if (createTransactionDto.TransactionType == "Deposit")
            {
                await ManageProccess(createTransactionDto, joinedAmountTypeWallet, Side.Deposit );
            }
            else if (createTransactionDto.TransactionType == "Drawing")
            {
                await ManageProccess(createTransactionDto, joinedAmountTypeWallet, Side.Drawing);
            }
            else if (createTransactionDto.TransactionType == "Transfer")
            {
                await ManageProccess(createTransactionDto, joinedAmountTypeWallet, Side.Transfer);
            }
        }
        public async Task ManageProccess(CreateTransactionDto createTransactionDto, IEnumerable<AmountTypeWalletJoin> joinedAmountTypeWallets, Side side)
        {
            var df = double.Parse(createTransactionDto.TotalAmount, CultureInfo.InvariantCulture);
            Wallet wallet = new Wallet();
            AmountTypeWallet amountTypeWallet = new AmountTypeWallet();

            _unitOfWork.Wallets.DetachEntity();
            _unitOfWork.AmountTypeWallets.DetachEntity();
            foreach (var joinedCoinWallet in joinedAmountTypeWallets)
            {
                var totalWelthOfWallet = double.Parse(joinedCoinWallet.TotalWelthOfWallet, CultureInfo.InvariantCulture); //cüzdandaki toplam miktar (wallet tablosuna kaydolur)
                totalWelthOfWallet = totalWelthOfWallet + (side == Side.Deposit ? 1 : -1) * double.Parse(createTransactionDto.TotalAmount, CultureInfo.InvariantCulture);
                wallet.TotalWealth = totalWelthOfWallet.ToString(CultureInfo.InvariantCulture);

                //ilgili paranın toplam adet sayısı
                var amountOfCoin = double.Parse(joinedCoinWallet.AmountOfAmountType, CultureInfo.InvariantCulture);
                amountOfCoin = amountOfCoin + (side == Side.Deposit ? 1 : -1) * double.Parse(createTransactionDto.AmountTypeAmount, CultureInfo.InvariantCulture);
                amountTypeWallet.AmountOfAmountType = amountOfCoin.ToString(CultureInfo.InvariantCulture);

                //ilgili paranın toplam sahip olunan fiyat miktarı
                var totalWelthOfCoin = double.Parse(joinedCoinWallet.TotalWelthOfAmountType, CultureInfo.InvariantCulture);//ilgili coininin total sahip olunan fiyatı
                totalWelthOfCoin = totalWelthOfCoin + (side == Side.Deposit ? 1 : -1) * double.Parse(createTransactionDto.TotalAmount, CultureInfo.InvariantCulture);
                amountTypeWallet.TotalWelthOfAmountType = totalWelthOfCoin.ToString(CultureInfo.InvariantCulture);//ilgili coinin total sahip olunan yeni fiyatı (coinwallet tablosuna kaydolur)


                var avarage = totalWelthOfCoin / amountOfCoin;
                amountTypeWallet.AvarageBuyPrice = avarage.ToString(CultureInfo.InvariantCulture);

                wallet.AccountId = joinedCoinWallet.AccountId;
                wallet.Id = joinedCoinWallet.WalletId;
                amountTypeWallet.AmountTypeId = joinedCoinWallet.AmountTypeId;
                amountTypeWallet.WalletId = joinedCoinWallet.WalletId;
                amountTypeWallet.Id = joinedCoinWallet.AmountTypeWalletId;
            }
            wallet.IsDeleted = false;
            wallet.IsActive = true;
            amountTypeWallet.IsActive = true;
            amountTypeWallet.IsDeleted = false;

            await _unitOfWork.AmountTypeWallets.UpdateAsync(amountTypeWallet);
            await _unitOfWork.Wallets.UpdateAsync(wallet); //.ContinueWith(t=>_UnitOfWork.SaveAsync())
            await _unitOfWork.SaveAsync(); //ContinueWith(x =>

            if(side==Side.Transfer)
            {
                var accountId = await _accountService.GetAccountIdWithIbanFromAccount(createTransactionDto.Iban);
                createTransactionDto.TransactionType = "Deposit"; //eklenecek
               await ManageTransaction(createTransactionDto, accountId);
            }

        }
     
    }
}
