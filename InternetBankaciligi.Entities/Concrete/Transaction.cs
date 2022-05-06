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
        /// <summary>
        /// işlemin miktarını belirtir. 
        /// </summary>
        public string Amount { get; set; }
        public string TransactionTypeName { get; set; }
        public string AmountTypeName { get; set; }
        /// <summary>
        /// yapılan işlemin fiyatını belirtir.
        /// </summary>
        public string TransactionPrice { get; set; }
        public string TotalPrice { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        //public int AmountTypeId { get; set; }
        //public AmountType AmountType { get; set; }
    }
}
