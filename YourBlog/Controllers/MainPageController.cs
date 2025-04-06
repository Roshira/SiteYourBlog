using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YourBlog.Models;

namespace YourBlog.Controllers
{
    public class MainPageController : Controller
    {
        private readonly ILogger<MainPageController> _logger;

        public MainPageController(ILogger<MainPageController> logger)
        {
            _logger = logger;
        }

        public IActionResult ShowMainPage()
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