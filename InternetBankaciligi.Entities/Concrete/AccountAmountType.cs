using InternetBankaciligi.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Entities.Concrete
{
    public class AccountAmountType: EntityBase, IEntity
    {
        public string Amount { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int AmountTypeId { get; set; }
        public AmountType AmountType { get; set; }

    }
}
