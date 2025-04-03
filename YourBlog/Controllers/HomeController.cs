// Controllers/HomeController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourBlog.Models;
using YourBlog.Models.Data;
using System.Security.Claims;

namespace YourBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly YourBlogDBContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            YourBlogDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var isAuthenticated = User.Identity.IsAuthenticated;
            var isSubscribed = User.HasClaim("IsSubscribed", "true");

            var newsQuery = _context.News.AsQueryable();

            if (!isAuthenticated)
            {
                newsQuery = newsQuery.Where(n => n.AccessLevel == 0); // Тільки публічні
            }
            else if (!isSubscribed)
            {
                newsQuery = newsQuery.Where(n => n.AccessLevel <= 1); // Публічні + для авторизованих
            }
            // Для підписників - всі новини

            var news = await newsQuery
                .OrderByDescending(n => n.CreatedAt)
                .Take(10)
                .ToListAsync();

            return View(news);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateNews()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateNews(News news)
        {
            if (ModelState.IsValid)
            {
                news.CreatedAt = DateTime.UtcNow;
                news.AuthorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // Інші методи...
    }
}