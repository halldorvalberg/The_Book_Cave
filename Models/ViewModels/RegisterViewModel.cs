using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vinsamlegast fylltu inn netfang")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vinsamlegast fylltu inn fornafn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Vinsamlegast fylltu inn eftirnafn")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Vinsamlegast fylltu inn lykilorð")]
        public string Password { get; set; }
    }
}