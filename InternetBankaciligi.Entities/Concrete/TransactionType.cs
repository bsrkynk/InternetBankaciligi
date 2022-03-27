using InternetBankaciligi.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Entities.Concrete
{
    public class TransactionType: EntityBase, IEntity
    {
        public string TransactionName { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
    }
}
