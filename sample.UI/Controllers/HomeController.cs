using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using sample.UI.Models;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
namespace sample.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

        }

        public async Task<IActionResult> Index()
        {
           var data = new externalapi();
           var  url =   _config.GetValue<string>("NODE_API");
          //var  url = "http://localhost:3001/";
            var val = await url.GetStringAsync();
            data.response = val;
            var user = JsonConvert.DeserializeObject<List<userData>>(val);
            return View(user.First());
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
