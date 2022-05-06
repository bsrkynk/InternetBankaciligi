using InternetBankaciligi.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Entities.Concrete
{
    public class AmountTypeWallet: EntityBase, IEntity
    {
        public int AmountTypeId { get; set; }
        /// <summary>
        /// ilgili paritenin ortalama alış maliyetini gösterir 
        /// </summary>
        public string AvarageBuyPrice { get; set; }
        /// <summary>
        /// ilgili parite bazında sahip olunan parite adetini gösterir
        /// </summary>
        public string AmountOfAmountType { get; set; }
        /// <summary>
        /// ilgili parite bazında sahip olunan toplam değeri gösterir
        /// </summary>
        public string TotalWelthOfAmountType { get; set; }
        public AmountType AmountType { get; set; }
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }

    }
}
