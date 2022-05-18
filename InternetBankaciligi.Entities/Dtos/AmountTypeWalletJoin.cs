using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Entities.Dtos
{
    public class AmountTypeWalletJoin
    {
        public int AmountTypeWalletId { get; set; }
        public string TotalWelthOfAmountType { get; set; }
        public int WalletId { get; set; }
        public int AmountTypeId { get; set; }
        public int AccountId { get; set; }
        public string AmountPrice { get; set; }
        public string TotalWelthOfWallet { get; set; }  
        public string AmountOfAmountType { get; set; }  
        public string AvarageBuyPrice { get; set; }
        public string AmountTypeName { get; set; }
        public string Iban { get; set; }
    }
}
