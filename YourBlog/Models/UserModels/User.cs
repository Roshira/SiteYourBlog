﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace YourBlog.Models.UserModels
{
    public class User : IdentityUser
    {
        [Required]
        [Display(Name = "Login")]
        public override string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Mail")]
        public override string Email { get; set; }

        [Display(Name = "Subscribe")]
        public bool IsSubscribed { get; set; } = false;
    }
}