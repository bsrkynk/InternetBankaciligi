using InternetBankaciligi.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Entities.Concrete
{
    public class Wallet:EntityBase,IEntity
    {
        /// <summary>
        /// toplam varlık, transaction tablosunda işlem olduğunda hesaplanır.
        /// </summary>
        public string TotalWealth { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; } //bir wallet bir acounta ait olabilir
        public ICollection<AmountType> AmountTypes { get; set; } //bir walletta çok sayıda para tipi olabilir.
    }
}
