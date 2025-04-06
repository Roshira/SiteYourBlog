using Microsoft.AspNetCore.Mvc;

namespace YourBlog.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
