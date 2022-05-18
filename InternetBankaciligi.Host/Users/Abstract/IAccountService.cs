using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBankaciligi.Entities.Concrete;
using InternetBankaciligi.Entities.Dtos;

namespace InternetBankaciligi.Host.Users.Abstract
{
    public interface IAccountService
    {
        Task<List<Account>> GetAllUserAccounts(int userId);
        Task<List<Account>> GetUserAccount(int userId);
        public Task AddAccount(CreateAccountDto createAccountDto);
        public  Task<int> GetAccountIdWithIbanFromAccount(string iban);
        public  Task<int> GetWalletIdWithIbanFromAccount(string iban);
    }
}
