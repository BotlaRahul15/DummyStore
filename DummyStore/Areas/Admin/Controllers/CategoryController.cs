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
    public class CategoryController : Controller
    {
        private ApplicationConfig _applicationConfig { get; set; }
        public CategoryController(IOptions<ApplicationConfig> appConfig)
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
            List<Category> categoryList = new List<Category>();
            string url = _applicationConfig.ApiUrl + "products/categories";
            HttpResponseMessage response = await HttpResponse.HttpRequestHeaderMethod("", HttpMethod.Get, url, "");
            if (response.IsSuccessStatusCode)
            {
                string res = response.Content.ReadAsStringAsync().Result;
                categoryList = JsonConvert.DeserializeObject<List<Category>>(res);
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }
            return Json(new { data = categoryList });
        }
    }
}
