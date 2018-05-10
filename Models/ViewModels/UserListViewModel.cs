using System.ComponentModel.DataAnnotations;

namespace The_Book_Cave.Models.ViewModels
{
    public class UserListViewModel
    {
        public string Name { get; set; }
        [Key]
        public string Email { get; set; }
        public string StreetName {get; set;}
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}