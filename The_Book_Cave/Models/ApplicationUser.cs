using Microsoft.AspNetCore.Identity;

namespace The_Book_Cave.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string FavoriteBook { get; set; }
        public string Address {get; set;}
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}