using InternetBankaciligi.Entities.Concrete;
using InternetBankaciligi.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Data.Abstract
{
   public interface IAccountRepository:IEntityRepository<Account>
    {
    }
}
