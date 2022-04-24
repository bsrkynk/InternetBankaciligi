using InternetBankaciligi.Data.Abstract;
using InternetBankaciligi.Entities.Concrete;
using InternetBankaciligi.Shared.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;



namespace InternetBankaciligi.Data.Concrete.EntityFramework.Repositories
{
    public class UserRepository: EfEntityRepositoryBase<User>, IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<int> SignInUser(User user)
        {
            var result = await _context.Set<User>().FirstOrDefaultAsync(x => x.TCNo.Equals(user.TCNo) && x.Password.Equals(user.Password));
            if (result != null)
            {
                return result.Id;
            }
            return -1;
        }
    }
}
