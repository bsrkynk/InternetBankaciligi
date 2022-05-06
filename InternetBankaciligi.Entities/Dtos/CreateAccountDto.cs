using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Entities.Dtos
{
    public class CreateAccountDto
    {
        public string AccountName { get; set; }
        public int UserId { get; set; }
    }
}
