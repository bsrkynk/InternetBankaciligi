using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBankaciligi.Entities.API;
using InternetBankaciligi.Host.Extensions;

namespace InternetBankaciligi.MVC
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<ExchangeRateInfo> exchangeRateInfos = APIHelper.HomeIndex();
            return View(exchangeRateInfos);
        }
    }
}
