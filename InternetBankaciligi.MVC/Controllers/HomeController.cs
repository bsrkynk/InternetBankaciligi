using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBankaciligi.Entities.API;
using InternetBankaciligi.Host.Extensions;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace InternetBankaciligi.MVC.Controllers
{

    public class HomeController : Controller
    {

        private readonly IStringLocalizer<HomeController> _stringLocalizer;
        private string culture = string.Empty;
        public HomeController(IStringLocalizer<HomeController> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public IActionResult Index()
        {
            ViewData["Giris"] = _stringLocalizer.GetString("Giris");
            List<ExchangeRateInfo> exchangeRateInfos = APIHelper.HomeIndex();
            return View(exchangeRateInfos);
        }

        [HttpPost]
        public IActionResult ChangeLanguage(string returnUrl)
        {
            culture = Request.Form["culture"];
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(7)
                    }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
