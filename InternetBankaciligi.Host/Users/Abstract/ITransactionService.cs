using InternetBankaciligi.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Host.Users.Abstract
{
    public interface ITransactionService
    {
        Task<bool> ManageTransaction(CreateTransactionDto addtransactionDto, int instanceAccountId);
    }
}
