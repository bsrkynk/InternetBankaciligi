using InternetBankaciligi.Shared.Entities.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Entities.Concrete
{
    public class Transaction : EntityBase, IEntity
    {
        public string Amount { get; set; }
        public string TransactionTypeName { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int AmountTypeId { get; set; }
        public AmountType AmountType { get; set; }
    }
}
