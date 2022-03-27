using InternetBankaciligi.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Entities.Concrete
{
    public class AccountType: EntityBase,IEntity
    {
        public string TypeName { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }

    }
}
