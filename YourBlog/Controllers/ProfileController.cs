using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YourBlog.Models.ViewModels;

namespace YourBlog.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<UserViewModel> _userManager;

        public ProfileController(UserManager<UserViewModel> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> YourProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // Явно вказуємо, що хочемо відобразити представлення "Index"
            return View("Index", user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Validation error: {error.ErrorMessage}");
                }
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            user.FullName = model.FullName;
            user.Bio = model.Bio;
            user.ProfilePictureUrl = model.ProfilePictureUrl;

            try
            {
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        Console.WriteLine($"User update error: {error.Description}");
                    }
                    return View(model);
                }

                TempData["SuccessMessage"] = "Profile updated successfully!";
                return RedirectToAction("YourProfile");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during profile update: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating your profile.");
                return View(model);
            }
        }
    }
}
