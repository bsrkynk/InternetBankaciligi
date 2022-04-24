using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBankaciligi.Entities.Dtos;

namespace InternetBankaciligi.Host.Users.Abstract
{
    public interface IUserService
    {
        Task Add(UserAddDto userAddDto);
        Task<int> SignInUser(SignInUserDto signInUserDto);
    }
}
