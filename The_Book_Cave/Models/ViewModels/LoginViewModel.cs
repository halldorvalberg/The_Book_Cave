using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Models.ViewModels
{
    public class LoginViewModel
    {
        
        [EmailAddress]
        [Required(ErrorMessage="Vinsamlegast fylltu inn netfang")]
        public string Email { get; set; }

        [Required(ErrorMessage="Vinsamlegast fylltu inn lykilorð")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}