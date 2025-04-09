using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourBlog.Models.Data;
using YourBlog.Models.ViewModel;
using YourBlog.Models.ViewModels;

namespace YourBlog.Controllers.Accounts
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly YourBlogDBContext _context;
        private readonly UserManager<UserViewModel> _userManager;

        public AdminController(YourBlogDBContext context, UserManager<UserViewModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Керування користувачами
        public async Task<IActionResult> ManageUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        // Керування новинами
        public async Task<IActionResult> ManageNews()
        {
            var news = await _context.News.ToListAsync();
            return View(news);
        }

        // Додавання новини
        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNews(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.UtcNow;
                _context.News.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageNews");
            }
            return View(model);
        }

        // Редагування новини
        [HttpGet]
        public async Task<IActionResult> EditNews(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        [HttpPost]
        public async Task<IActionResult> EditNews(int id, NewsViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    model.UpdatedAt = DateTime.UtcNow;
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ManageNews");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> YourProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // Перевіряємо, чи користувач є адміністратором
            ViewBag.IsAdmin = await _userManager.IsInRoleAsync(user, "Адмін");
            return View(user);
        }

        // Видалення новини
        public async Task<IActionResult> DeleteNews(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                _context.News.Remove(news);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ManageNews");
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}