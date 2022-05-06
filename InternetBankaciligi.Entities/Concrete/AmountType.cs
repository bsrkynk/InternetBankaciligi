using InternetBankaciligi.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Entities.Concrete
{
    public class AmountType: EntityBase, IEntity
    {
        public string AmountName { get; set; }
        public string AmountPrice { get; set; } //işleme giren paranın o anki karşılığı
        public ICollection<Wallet> Wallets { get; set; } //bir walletta çok sayıda para tipi olabilir.




    }
}
