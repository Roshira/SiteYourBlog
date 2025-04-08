using Microsoft.AspNetCore.Mvc;


namespace YourBlog.Controllers


{
    public class NewsController : Controller
    {
        public IActionResult News()
        {
            return View();
        }
    } 
}
