using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YourBlog.Models.ViewModels;

namespace YourBlog.Models.Users
{
    public class Profile
    {
        [Required]
        [Display(Name = "Login")]
        public  string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Mail")]
        public  string Email { get; set; }

        [Display(Name = "Subscribe")]
        public bool IsSubscribed { get; set; } = false;

        public string? FullName { get; set; }

        [Display(Name = "Bio")]
        [StringLength(500, ErrorMessage = "Bio cannot be longer than 500 characters.")]
        public string? Bio { get; set; }

        public string? ProfilePictureUrl { get; set; }

        [Display(Name = "Profile Created")]
        public DateTime ProfileCreated { get; set; }

    }
}