using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Models.ViewModels
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Image { get; set; }
        public string Address { get; set; }
        public string FavoriteBook { get; set; }
    }
}