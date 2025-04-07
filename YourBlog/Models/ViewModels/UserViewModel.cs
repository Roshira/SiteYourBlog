// In Models/ViewModels/UserViewModel.cs
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace YourBlog.Models.ViewModels
{
    public class UserViewModel : IdentityUser
    {
        [Required]
        [Display(Name = "Login")]
        public override string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public override string Email { get; set; }

        [Display(Name = "Subscribe to newsletter")]
        public bool IsSubscribed { get; set; } = false;

        [Display(Name = "Full Name")]
        public string? FullName { get; set; }

        [Display(Name = "Bio")]
        [StringLength(500, ErrorMessage = "Bio cannot be longer than 500 characters.")]
        public string? Bio { get; set; }

        [Display(Name = "Profile Picture URL")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        public string? ProfilePictureUrl { get; set; }

        [Display(Name = "Profile Created")]
        public DateTime ProfileCreated { get; set; } = DateTime.UtcNow;
    }
}