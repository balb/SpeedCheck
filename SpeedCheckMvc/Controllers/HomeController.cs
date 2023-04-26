using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using SpeedCheckMvc.Models;

namespace SpeedCheckMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var sw = Stopwatch.StartNew();
            var mySHA256 = SHA256.Create();
            for (var i = 0; i < 1000000; i++)
            {
                var result = mySHA256.ComputeHash(Guid.NewGuid().ToByteArray());
            }

            sw.Stop();
            return View(new { sw.ElapsedMilliseconds });
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