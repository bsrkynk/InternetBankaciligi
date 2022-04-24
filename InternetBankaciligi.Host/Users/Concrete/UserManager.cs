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

        public async Task Add(UserAddDto userAddDto)
        {
            await _unitOfWork.Users.AddAsync(new User
            {
                Name = userAddDto.Name,
                Surname = userAddDto.Surname,
                TCNo = CustomerSecurityOperationHelper.MaskTCNo(userAddDto.TCNo),
                CustomerNo = CustomerSecurityOperationHelper.GenerateCustomerNumber(userAddDto.TCNo),
                Password = CustomerSecurityOperationHelper.ComputeSha256HashPassword(userAddDto.UserPassword),
                Accounts = null,
                IsActive = true,
                IsDeleted = false

            });
            await _unitOfWork.SaveAsync();

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
