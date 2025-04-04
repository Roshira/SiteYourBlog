using System.ComponentModel.DataAnnotations;

namespace YourBlog.Models.Users.Auth
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login or Email")]
        public string UserNameOrEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}