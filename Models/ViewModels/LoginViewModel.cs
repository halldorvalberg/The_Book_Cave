using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Models.ViewModels
{
    public class LoginViewModel
    {

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}