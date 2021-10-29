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

namespace DummyStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private ApplicationConfig _applicationConfig { get; set; }
        public UserController(IOptions<ApplicationConfig> appConfig)
        {
            _applicationConfig = appConfig.Value;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<User> userList = await GetUsers();
            //int count = await GetCartValue(1);
            return Json(new { data = userList });
        }
        public async Task<List<User>> GetUsers()
        {
            List<User> userList = new List<User>();
            string url = _applicationConfig.ApiUrl + "users";
            HttpResponseMessage response = await HttpResponse.HttpRequestHeaderMethod("", HttpMethod.Get, url, "");
            if (response.IsSuccessStatusCode)
            {
                string res = response.Content.ReadAsStringAsync().Result;
                userList = JsonConvert.DeserializeObject<List<User>>(res);
                foreach (var user in userList)
                {
                    user.FullName = user.name.Firstname + " " + user.name.Lastname;
                }
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }
            return userList;
        }
        public async Task<int> GetCartValue(int userId)
        {
            int count = 0;
            List<Cart> cartList = new List<Cart>();
            string url = _applicationConfig.ApiUrl + "carts/user/"+userId;
            HttpResponseMessage response = await HttpResponse.HttpRequestHeaderMethod("", HttpMethod.Get, url, "");
            if (response.IsSuccessStatusCode)
            {
                string res = response.Content.ReadAsStringAsync().Result;
                cartList = JsonConvert.DeserializeObject<List<Cart>>(res);
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }
            count = cartList == null ? 0 : cartList.Count();
            return count;
        }

    }
}
