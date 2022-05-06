using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using InternetBankaciligi.Data.Concrete.EntityFramework.Contexts;
using InternetBankaciligi.Data.Abstract;
using InternetBankaciligi.Data.Concrete;
using InternetBankaciligi.Host.Users.Abstract;
using InternetBankaciligi.Host.Users.Concrete;


namespace InternetBankaciligi.Host.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<InternetBankaciligiContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IUserService, UserManager>();
            serviceCollection.AddScoped<IAccountService, AccountManager>();
            serviceCollection.AddScoped<IAmountTypeWalletService, AmountTypeWalletManager>();
            serviceCollection.AddScoped<IWalletService, WalletManager>();
            serviceCollection.AddScoped<IAmountTypeService, AmountTypeManager>();
            serviceCollection.AddScoped<ITransactionService, TransactionManager>();
            return serviceCollection;
        }
    }
}
