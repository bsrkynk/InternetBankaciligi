using InternetBankaciligi.Entities.Dtos;
using InternetBankaciligi.Host.Users.Abstract;
using InternetBankaciligi.MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace InternetBankaciligi.MVC.Controllers
{
    public class Varliklar : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IAmountTypeWalletService _amountTypeWalletService;
        private readonly IAmountTypeService _amountTypeService;
        private readonly ITransactionService _transactionService;
        private readonly AccountViewModel _accountViewModel;

        public Varliklar(IAccountService accountService,AccountViewModel accountViewModel,IAmountTypeWalletService amountTypeWalletService, IAmountTypeService amountTypeService,ITransactionService transactionService)
        {
            _accountService = accountService;
            _accountViewModel = accountViewModel;
            _amountTypeWalletService = amountTypeWalletService;
            _amountTypeService = amountTypeService;
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {     
            var accounts = await _accountService.GetAllUserAccounts(Convert.ToInt32(HttpContext.Session.GetInt32("USERID")));
            if (accounts != null)
            {
                _accountViewModel.UserAccounts = accounts;
            }
            return View(_accountViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int id, bool check)//////////////////////////////////////////////////////////PORTFÖY ID=COİN KAYDEDERKEN PORTFÖYDEN WALLETI BUL, TRANSACTION YAPARKEN BUNU KULLAN, WALLETA YAZDIMAK İÇİN BUNA BAK. İKİ NUMARALI PORTFÖY 1 NUMARALI WALLETI VE OLUŞTURULAN COİNİ KULLANIYOR ONA GÖRE YAZ SESSİONA AT
        {
            HttpContext.Session.SetInt32("AccountId", id);
            var account = await _accountService.GetUserAccount(id);
            if (account != null)
            {
                _accountViewModel.UserAccounts = account;
            }

            var amountTypes = await _amountTypeService.GetAllAmountTypes();
            var amountNames = (from i in amountTypes.ToList()
                             select new SelectListItem
                             {
                                 Text = i.AmountTypeName
                             }).ToList();
            ViewBag.dgr = amountNames;
            _accountViewModel.AmountTypeWallets = await _amountTypeWalletService.GetUserWallet(id);

            _accountViewModel.CheckAccountPartial = check;
            return View(_accountViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccountViewModel accountViewModel)
        {
            accountViewModel.CreateAccountDto.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("USERID"));
            await _accountService.AddAccount(accountViewModel.CreateAccountDto);
            return RedirectToAction("Index");
        }     
        public async Task<IActionResult> BeginTransaction(CreateTransactionDto createTransactionDto)
        {
            var accountId = Convert.ToInt32(HttpContext.Session.GetInt32("AccountId"));
            createTransactionDto.TransactionType = "Deposit"; //para yatırma
            var checkAmount = await _transactionService.ManageTransaction(createTransactionDto, accountId);
            ViewBag.type = checkAmount;
            return RedirectToAction("Index");
        }

    }
}
