using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Models.ViewModels
{
    public class LoginViewModel
    {
        
        [EmailAddress]
        [Required(ErrorMessage="Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage="Password is required")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}