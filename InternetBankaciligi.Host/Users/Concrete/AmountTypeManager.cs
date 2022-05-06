using InternetBankaciligi.Data.Abstract;
using InternetBankaciligi.Entities.Concrete;
using InternetBankaciligi.Entities.Dtos;
using InternetBankaciligi.Host.Users.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Host.Users.Concrete
{
    public class AmountTypeManager : IAmountTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AmountTypeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IList<CreateTransactionDto>> GetAllAmountTypes()
        {
            var result = await _unitOfWork.AmountTypes.GetAllAsync();        
            var uw = result.Select(x => new CreateTransactionDto { AmountTypeName = x.AmountName }).ToList();
            return uw.ToList();       
        }
        public async Task<int> AddAmountType(CreateTransactionDto addAmountTypeDto)
        {
            var isExist = await _unitOfWork.AmountTypes.AnyAsync(x => x.AmountName == addAmountTypeDto.AmountTypeName);

            if (isExist)
            {
                var type = await _unitOfWork.AmountTypes.GetAllAsync(x => x.AmountName == addAmountTypeDto.AmountTypeName);
                var typeId = type.Select(x => x.Id).FirstOrDefault();
                return typeId;
            }
            else
            {
                AmountType addAmountType = new AmountType
                {
                    AmountName = addAmountTypeDto.AmountTypeName,
                    AmountPrice = addAmountTypeDto.AmountTypePrice
                };
                await _unitOfWork.AmountTypes.AddAsync(addAmountType);
                await _unitOfWork.SaveAsync();
                return addAmountType.Id; //en son eklenen paranın idsini döndürür
            }

        }
    }
}
