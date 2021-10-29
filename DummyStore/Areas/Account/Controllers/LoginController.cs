using DummyStore.Areas.Admin.Controllers;
using DummyStore.Controllers;
using DummyStore.Helpers;
using DummyStore.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DummyStore.Areas.Account.Controllers
{
    [Area("Account")]
    public class LoginController : Controller
    {
        UserController uc;//= new HomeController();
        private ApplicationConfig _applicationConfig { get; set; }
        public LoginController(IOptions<ApplicationConfig> appConfig)
        {
            _applicationConfig = appConfig.Value;
            uc = new UserController(appConfig);
        }
        public IActionResult Index()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(User user)
        {
            List<User> userList= await uc.GetUsers();
            User loginUser = userList.Find(x => x.Email == user.Email && x.Password == user.Password);
            if (loginUser != null)
            {
                int count = await uc.GetCartValue(loginUser.Id);
                HttpContext.Session.SetObject("ShppingCount", count);
                HttpContext.Session.SetObject("LoggedUser", loginUser.Email);
                return RedirectToAction("Index", "Home", new { area = "Home" });
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }
            return View();
        }
    }
}
