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
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Transaction> Transactions { get; set; }


    }
}
