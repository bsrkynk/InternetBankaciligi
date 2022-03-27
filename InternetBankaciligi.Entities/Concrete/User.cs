using InternetBankaciligi.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Entities.Concrete
{
    public class User: EntityBase,IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNo { get; set; }
        public string CustomerNo { get; set; }
        public string Password { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
