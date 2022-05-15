using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBankaciligi.Data.Concrete.EntityFramework.Contexts;
using InternetBankaciligi.Data.Abstract;
using InternetBankaciligi.Entities.Dtos;
using InternetBankaciligi.Host.Users.Abstract;
using InternetBankaciligi.Host.Extensions;
using InternetBankaciligi.Entities.Concrete;
using System.Security.Cryptography;

namespace InternetBankaciligi.Host.Users.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async  Task<int> Add(UserAddDto userAddDto)
        {
            User user = new User();

            user.Name = userAddDto.Name;
            user.Surname = userAddDto.Surname;
            user.TCNo = CustomerSecurityOperationHelper.MaskTCNo(userAddDto.TCNo);
            user.CustomerNo = CustomerSecurityOperationHelper.GenerateCustomerNumber(userAddDto.TCNo);
            user.Password = CustomerSecurityOperationHelper.ComputeSha256HashPassword(userAddDto.UserPassword);
            user.Accounts = null;
            user.IsActive = true;
            user.IsDeleted = false;
            string iban = IbanCalculator.GenerateIban(user.CustomerNo);

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveAsync();
            return user.Id;
        }

        public async Task<int> SignInUser(SignInUserDto signInUserDto)
        {
            return await
                _unitOfWork.Users.SignInUser(new User
                {
                    TCNo = CustomerSecurityOperationHelper.MaskTCNo(signInUserDto.TCNo),
                    Password = CustomerSecurityOperationHelper.ComputeSha256HashPassword(signInUserDto.UserPassword)
                });

        }
    }
}
