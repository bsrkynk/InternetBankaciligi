using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBankaciligi.Entities.Dtos;
using InternetBankaciligi.Host.Users.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace InternetBankaciligi.MVC.Controllers
{
    public class LoginController : Controller
    {

        private readonly IStringLocalizer<LoginController> _stringLocalizer;     
        private readonly IUserService _userService;

        public LoginController(IUserService userService, IStringLocalizer<LoginController> stringLocalizer)
        {
            _userService = userService;
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserAddDto userAddDto) //async yapılmazsa kaydetmiyor
        {
           int addedUserId= await _userService.Add(userAddDto);
            SaveDataWithSession(addedUserId);
            return Redirect("/Varliklar/Index/");
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInUserDto signInUserDto)
        {
            var result = await _userService.SignInUser(signInUserDto);
            if (result != -1)
            {
                SaveDataWithSession(result);
                return Redirect("/Varliklar/Index/");
            }

            return Redirect("/Home/Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Redirect("/Home/Index");

        }

        private void SaveDataWithSession(int result)
        {
            HttpContext.Session.SetInt32("USERID", result); //login olan kullanıcının usernameini sessiona kaydediyor

        }
    }
}

