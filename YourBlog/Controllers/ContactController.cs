using Microsoft.AspNetCore.Mvc;

namespace YourBlog.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
