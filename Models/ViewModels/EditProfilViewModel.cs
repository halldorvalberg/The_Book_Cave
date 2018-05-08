using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Models.ViewModels
{
    public class EditProfileViewModel
    {
      [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Image { get; set; }
        public string Address { get; set; }
        public string Book { get; set; }
    }
}