using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Entities.Dtos
{
    public class CreateTransactionDto
    {
        public string AmountTypeName { get; set; }
        public string AmountTypePrice { get; set; }
        public string AmountTypeAmount { get; set; }
        public string TotalAmount { get; set; }
        public string TransactionType { get; set; }
        public bool IsSuccess { get; set; }
        public string Iban { get; set; }
    }
}
