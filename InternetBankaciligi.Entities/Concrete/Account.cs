using InternetBankaciligi.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Entities.Concrete
{
    public class Account: EntityBase,IEntity
    {
        public string AccountName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Wallet Wallet { get; set; }
        public int  WalletId { get; set; }
        public string Iban { get; set; }
        //public string AccountTypeName { get; set; }
        //public ICollection<AmountType> AmountTypes { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
