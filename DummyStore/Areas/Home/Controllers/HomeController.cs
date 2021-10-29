using DummyStore.Helpers;
using DummyStore.Models;
using DummyStore.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DummyStore.Controllers
{
    [Area("Home")]
    public class HomeController : Controller
    {
        public const string ssShoppingCart = "Shoping Cart Session";
        private readonly ILogger<HomeController> _logger;
        private ApplicationConfig _applicationConfig { get; set; }
        public HomeController(ILogger<HomeController> logger, IOptions<ApplicationConfig> appConfig)
        {
            _logger = logger;
            _applicationConfig = appConfig.Value;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> productList = new List<Product>();
            string url = _applicationConfig.ApiUrl + "products";
            HttpResponseMessage response = await HttpResponse.HttpRequestHeaderMethod("", HttpMethod.Get, url, "");
            if (response.IsSuccessStatusCode)
            {
                string res = response.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<List<Product>>(res);
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }
            //int count =  HttpContext.Session.GetObject<int>("ShppingCount");
            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
