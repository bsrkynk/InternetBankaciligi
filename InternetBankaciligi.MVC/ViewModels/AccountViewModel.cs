using InternetBankaciligi.Entities.Concrete;
using InternetBankaciligi.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBankaciligi.MVC.ViewModels
{
    public class AccountViewModel
    {
        public List<Account> UserAccounts { get; set; }
        public List<AmountTypeWalletJoin> AmountTypeWallets { get; set; }
        public CreateAccountDto CreateAccountDto { get; set; }
        public bool CheckAccountPartial { get; set; } = false;
        public CreateTransactionDto CreateTransactionDto { get; set; }
    }
}
