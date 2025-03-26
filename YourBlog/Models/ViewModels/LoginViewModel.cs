using System.ComponentModel.DataAnnotations;

namespace YourBlog.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Login field is required.")]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}